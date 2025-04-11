using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GameOverCondition
{
    Win,
    Ginseng,
    Lost
}

public class Level3 : LevelController
{
    public int point;
    public int lostGinseng;
    public int lostGinsengOver = 4;
    public TMP_Text pointText;
    public TMP_Text timeText;
    public int time = 100;

    public AudioSource ginsengGetAudio;
    public bool hasScore = true;
    private bool _gameStart = false;

    public Level3GameOver gameOverHandle;
    public void PointChange(int point)
    {
        ginsengGetAudio.Play();
        this.point += point;
        pointText.SetText(this.point.ToString());
    }

    public void LostGinsengChange(int count)
    {
        this.lostGinseng += count;
        if (lostGinseng >= lostGinsengOver)
        {
            GameOver(GameOverCondition.Ginseng);
        }
    }

    void FixedUpdate()
    {
        if (isStart && !_gameStart)
        {
            StartCoroutine(ChangeTime());
            GetComponent<RandomSpawn2D>().enabled = true;
            _gameStart = true;
        }

        if (Time.timeScale == 0)
        {
            GetComponent<RandomSpawn2D>().enabled = false;
        }
        // else if(!_gameStart && Time.timeScale>=1)
        // {
        //     GetComponent<RandomSpawn2D>().enabled = true;
        // }
    }

    private IEnumerator ChangeTime()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Time:").Append(" ").Append(time).Append("s");
            timeText.SetText(stringBuilder.ToString());
        }

        if (point > 0)
        {
            GameOver(GameOverCondition.Win);
        }
        else
        {
            GameOver(GameOverCondition.Lost);
        }
    }

    private void GameOver(GameOverCondition condition)
    {
        gameOverHandle.gameOverPage.SetActive(true);
        int best = 0;
        bool win = false;
        bool custommsg = false;
        string custommessage = "";
        try
        {
            best = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "-best");
        }
        catch (Exception e)
        {
            best = 0;
        }

        if (point > best)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "-best", point);
            best = point;
        }

        if (condition == GameOverCondition.Ginseng)
        {
            custommsg = true;
            custommessage = "镇元子发现了! Zhenyuan has discovered it!";
        }

        if (condition == GameOverCondition.Lost)
        {
            custommsg = true;
            custommessage = "没拿到人参果! Not enough Ginseng fruit!";
        }

        if (condition == GameOverCondition.Win)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "-success", 1);
            win = true;
        }

        gameOverHandle.Init(win,hasScore,point,best,custommsg,custommessage);
    }
}