using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SpeechLevelControl : LevelController
{
    public TextAsset speechDataJson;
    private List<SpeechLevel> _speechDataList;

    public Camera mainCamera;
    public GameObject gameLevelParent;
    public GameObject speechWall;
    public TMP_Text curText;
    public Vector3 startPos;
    public float posGap = 2f;

    public GameObject overPage;
    
    private Vector3 _nowPos;
    private int _count;
    private int _nowIndex = 0;

    private List<GameObject> _speechWallList;

    private bool isMoving = false;
    public float moveDuration = 1f;
    private Vector3 targetPosition;

    void Start()
    {
        _speechWallList = new List<GameObject>();
        SpeechLoad();
        SpawnLevelWall();
    }

    void Update()
    {
    }

    public void SpeechLoad()
    {
        if (speechDataJson != null)
        {
            _speechDataList = JsonUtility.FromJson<SpeechList>(speechDataJson.text).speechItems;
            _count = _speechDataList.Count;
        }
        else
        {
            Debug.LogError("JSON文件加载失败");
        }
    }

    public void SpawnLevelWall()
    {
        for (int i = 0; i < _speechDataList.Count; i++)
        {
            SpeechLevel level = _speechDataList[i];
            _nowPos = startPos + Vector3.right * i * posGap;
            GameObject o = Instantiate(speechWall, _nowPos, Quaternion.identity, gameLevelParent.transform);
            if (i == 0)
            {
                ChangeText();
            }
            _speechWallList.Add(o);
        }
    }

    private void ChangeText()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(_speechDataList[_nowIndex].answerCn).Append(" ")
            .Append(_speechDataList[_nowIndex].textPinyin);
        curText.SetText(stringBuilder.ToString());
    }


    public void isSuccessSpeech(string result)
    {
        SpeechLevel level = _speechDataList[_nowIndex];
        if (result.Contains(level.answerCn))
        {
            _speechWallList[_nowIndex].GetComponent<Collider2D>().enabled = false;
            Destroy(_speechWallList[_nowIndex].transform.GetChild(1).gameObject);
            if (_nowIndex < _count -1)
            {
                _nowIndex++;
                ChangeText();
                if (!isMoving)
                {
                    StartCoroutine(MoveCameraForward());
                }
            }
            else
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        overPage.SetActive(true);
    }
    
    IEnumerator MoveCameraForward()
    {
        isMoving = true;
        Vector3 startPosition = mainCamera.transform.position;
        targetPosition = startPosition + posGap * Vector3.right;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            t = Mathf.SmoothStep(0, 1, t);
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = targetPosition;
        isMoving = false;
    }
}