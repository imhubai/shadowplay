using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public LevelController levelController;
    public GameObject gameOverPage;
    public GameObject buttonNextLevel;
    public GameObject buttonRetry;
    public GameObject textScore;
    public GameObject imageWin;
    public GameObject imageLost;
    public TMP_Text textScoreText;
    public TMP_Text textMsgWin;
    public TMP_Text textMsgLost;

    public void GameQuit()
    {
        levelController.GameQuit();
    }
    public void GameRestart()
    {
        levelController.GameRestart();
    }
    
    public void GameNextLevel()
    {
        SceneManager.LoadScene(levelController.nextLevelSceneName);
    }

    private void Start()
    {
        if (levelController.nextLevelSceneName == "" || levelController.nextLevelSceneName.Equals(null))
        {
            buttonNextLevel.SetActive(false);
        }
    }
}