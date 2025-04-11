using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class studyUI : MonoBehaviour
{
    public AudioSource audioSound;
    public TMP_Text textPinyin;
    public TMP_Text textName;
    public TMP_Text textContent;
    public string pinyin;
    public string namecn;
    public string content;

    void Start()
    {
        textPinyin.SetText(pinyin);
        textName.SetText(namecn);
        textContent.SetText(content);
    }

    void Update()
    {
    }
    
    public void CloseWindow()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void PlaySound()
    {
        if (audioSound.isPlaying)
        {
            audioSound.Stop();
        }
        audioSound.Play();
    }
}