using UnityEngine;

public class GameMain : MonoBehaviour
{
    void Start()
    {
        LoadSettings();
    }

    void LoadSettings()
    {
        int fps = PlayerPrefs.GetInt("fps", 30);
        Application.targetFrameRate = fps;
        int screen = PlayerPrefs.GetInt("screen", 0);
        if (screen == 0)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.SetResolution(1920, 1080, false);
        }
    }
}