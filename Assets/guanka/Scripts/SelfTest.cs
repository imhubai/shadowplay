using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelfTest : LevelController
{
    public TMP_Text questionText;
    public List<TMP_Text> answerTexts;
    public List<GameObject> answerTextsSuccessImages;
    public List<GameObject> answerTextsFailImages;

    public GameObject imageWrong;
    public TMP_Text wrongAnswerText;
    public TMP_Text questionIndex;
    public TextAsset questionDataJson;

    public GameObject finishWindow;
    
    public int successQuestionCount = 0;
    private List<QuestionData> _questionDataList;

    private int _index = 0;
    private int _count;

    private int _correctIndex = 0;

    void Start()
    {
        QuestionLoad();
        QuestionStart(_index);
    }

    public void QuestionLoad()
    {
        if (questionDataJson != null)
        {
            _questionDataList = JsonUtility.FromJson<QuestionList>(questionDataJson.text).questionItems;
            _count = _questionDataList.Count;
        }
        else
        {
            Debug.LogError("JSON文件加载失败");
        }
    }

    public void AnswerClicked(int ans)
    {
        if (ans == _correctIndex)
        {
            successQuestionCount++;
            answerTextsSuccessImages[ans-1].SetActive(true);
            if (_index+1 < _count)
            {
                _index++;
                StartCoroutine(DelayNext());
            }
            else
            {
                TestOver();
            }
        }
        else
        {
            answerTextsFailImages[ans-1].SetActive(true);
            imageWrong.SetActive(true);
            string[] mapper = new[] { "A", "B", "C", "D" };
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("答错啦!正确答案是:\n").Append("Wrong answer, The correct answer is\n")
                .Append(mapper[_correctIndex - 1]).Append("、").Append(answerTexts[_correctIndex - 1].text);
            wrongAnswerText.SetText(stringBuilder.ToString());
        }
    }

    private void TestOver()
    {
        finishWindow.SetActive(true);
    }

    IEnumerator DelayNext()
    {
        yield return new WaitForSeconds(0.5f);
        QuestionStart(_index);
    }


    public void ExitWrongAnswerWindow()
    {
        imageWrong.SetActive(false);
    }

    public void ResetComponents()
    {
        StringBuilder stringBuilder = new StringBuilder();
        questionIndex.SetText(stringBuilder.Append(_index + 1).Append("/").Append(_count)
            .ToString());
        for (int i = 0; i < 4; i++)
        {
            answerTextsSuccessImages[i].SetActive(false);
            answerTextsFailImages[i].SetActive(false);
        }
    }

    public void QuestionStart(int index)
    {
        ResetComponents();
        QuestionData data = _questionDataList[index];
        _correctIndex = data.answer;
        questionText.SetText(data.question);
        answerTexts[0].SetText(data.contentA);
        answerTexts[1].SetText(data.contentB);
        answerTexts[2].SetText(data.contentC);
        answerTexts[3].SetText(data.contentD);
    }

    public void BackPlayMenu()
    {
        SceneManager.LoadScene("PlayMenu");
    }

    void Update()
    {
    }
}