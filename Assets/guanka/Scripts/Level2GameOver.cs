using System;
using System.Text;
using UnityEngine;

public class Level2GameOver : GameOver
{
    public void Init(bool win,bool hasScore,int score,int best,bool customMsg,string customMessage)
    {
        Time.timeScale = 0;
        if (win)
        {
            if (levelController.nextLevelSceneName != "" && !levelController.nextLevelSceneName.Equals(null))
            {
                buttonNextLevel.SetActive(true);
            }
            imageWin.SetActive(true);
        }
        else
        {
            buttonRetry.SetActive(true);
            buttonNextLevel.SetActive(false);
            imageLost.SetActive(true);
        }
        

        if (customMsg)
        {
            textMsgWin.SetText(customMessage);
            textMsgLost.SetText(customMessage);
        }
    }
}