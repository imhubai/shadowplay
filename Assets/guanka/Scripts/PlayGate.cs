using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡清单页面
/// </summary>
public class PlayGate : MonoBehaviour
{
    public RectTransform content;
    public GameObject levelContentPrefab;
    public TextAsset levelDataJson;
    private List<LevelInfo> _levelInfoList;

    private int _levelIndex = 0;
    public float _topPos = 800f;

    private int _count;
    private GameObject _temp;

    private void Start()
    {
        LevelInfoLoad();
        UIinit();
    }

    void UIinit()
    {
        foreach (LevelInfo levelInfo in _levelInfoList)
        {
            int best = -1;
            // if (levelInfo.isScoreLevel)
            // {
            //     try
            //     {
            //         best = PlayerPrefs.GetInt(levelInfo.levelSceneName + "-best");
            //     }
            //     catch (Exception e)
            //     {
            //         best = -1;
            //     }
            // }

            int isLocked = 1;
            try
            {
                if (PlayerPrefs.GetInt(levelInfo.levelSceneName + "-success") == 1)
                {
                    isLocked = 2;
                }
            }
            catch (Exception e)
            {
                isLocked = 1;
            }

            if (_levelIndex == 0 && PlayerPrefs.GetInt(levelInfo.levelSceneName + "-success", -1) == -1) isLocked = -1;

            _temp = Instantiate(levelContentPrefab, content.transform);
            _temp.GetComponent<LevelContent>().Init(levelInfo.name, levelInfo.levelSceneName, best, isLocked);
            _temp.GetComponent<RectTransform>().anchoredPosition =
                new Vector3(10.5f, _topPos + _levelIndex * (-150f), 0);
            _levelIndex++;
        }
    }

    public void LevelInfoLoad()
    {
        if (levelDataJson != null)
        {
            _levelInfoList = JsonUtility.FromJson<LevelList>(levelDataJson.text).levelItems;
            _count = _levelInfoList.Count;
        }
        else
        {
            Debug.LogError("JSON文件加载失败");
        }
    }
}

[System.Serializable]
public class LevelInfo
{
    public string name;
    public string levelSceneName;
    public bool isScoreLevel;
}


[System.Serializable]
public class LevelList
{
    public List<LevelInfo> levelItems;
}