using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Level的超类
/// 用于规范isStart变量搭配Dialogue组件使用
/// (Dialogue播放完才进行游戏关卡)
/// </summary>
public class LevelController : MonoBehaviour
{
    public GameObject pausePage;
    public bool isStart = false;
    public string nextLevelSceneName = "";
    
    private void Start()
    {
        Time.timeScale = 1;
    }
    
    public void LevelStart()
    {
        isStart = true;
    }

    public void GamePause()
    {
        pausePage.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        pausePage.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(sceneName: SceneManager.GetActiveScene().name);
    }
    public void GameQuit()
    {
        SceneManager.LoadScene("Level0");
    }
}