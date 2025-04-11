using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnChara : MonoBehaviour
{
    public GameObject learnUI;

    public void ShowLearnUI()
    {
        Time.timeScale = 0;
        learnUI.SetActive(true);
    }
}
