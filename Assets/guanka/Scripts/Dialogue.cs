using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// AVG类对话
/// </summary>
public class Dialogue : MonoBehaviour
{
    public TextAsset dialogueDataJson;
    private List<DialogueData> _dialogueDataList;

    public LevelController levelController;

    public int dialogueIndex = 0;

    public Image backGroundImage;
    public Image avatarChara;
    public TMP_Text textCharaName;
    public TMP_Text textCharaContent;
    public AudioSource audioChara;

    private int _count;

    private void Start()
    {
        Time.timeScale = 0;
        DialogueLoad();
        DialogueStart(0);
    }

    /// <summary>
    /// 退出对话
    /// </summary>
    private void OnDestroy()
    {
        // GOTO level
        Time.timeScale = 1;
        // 开始关卡
        levelController.LevelStart();
    }

    /// <summary>
    /// 加载对话内容Json到List
    /// </summary>
    public void DialogueLoad()
    {
        if (dialogueDataJson != null)
        {
            _dialogueDataList = JsonUtility.FromJson<DialogList>(dialogueDataJson.text).dialogItems;
            _count = _dialogueDataList.Count;
        }
        else
        {
            Debug.LogError("JSON文件加载失败");
        }
    }

    /// <summary>
    /// 点击对话框事件
    /// </summary>
    public void NextClicked()
    {
        dialogueIndex++;
        if (dialogueIndex == _count)
        {
            Destroy(this.gameObject);
            return;
        }

        DialogueStart(dialogueIndex);
    }

    /// <summary>
    /// 更新当前对话内容与背景
    /// </summary>
    /// <param name="index">当前对话索引</param>
    public void DialogueStart(int index)
    {
        DialogueData data = _dialogueDataList[index];
        if (data.hasImageChange)
        {
            Debug.Log(data.imageFileName);
            if (data.imageFileName.Equals("none"))
            {
                Sprite image = Resources.Load<Sprite>("T") as Sprite;
                backGroundImage.sprite = image;
            }
            else
            {
                Sprite image = Resources.Load<Sprite>(data.imageFileName) as Sprite;
                backGroundImage.sprite = image;
            }
        }

        if (data.hasAvatar)
        {
            if (data.avatarFileName.Equals("none"))
            {
                avatarChara.GetComponent<Image>().color = new Color(1,1,1,0);
            }
            else
            {
                Sprite image = Resources.Load<Sprite>(data.avatarFileName) as Sprite;
                avatarChara.sprite = image;
                backGroundImage.GetComponent<Image>().color = Color.white;
            }
        }

        if (data.hasSound)
        {
            AudioClip audioSource = Resources.Load<AudioClip>("Sounds/" + data.soundFileName);
            if (audioChara.isPlaying)
            {
                audioChara.Stop();
            }
            audioChara.clip = audioSource;
            audioChara.Play();
        }

        textCharaName.SetText(data.characterName);
        textCharaContent.SetText(data.content);
    }
}