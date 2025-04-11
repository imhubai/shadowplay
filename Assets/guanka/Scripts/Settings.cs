using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public ToggleGroup fpsToggleGroup;
    public List<Toggle> fpsToggleList;
    public ToggleGroup windowToggleGroup;
    public List<Toggle> windowToggleList;

    public TMP_Text fpsCurrentText;
    public TMP_Text windowCurrentText;

    private void Start()
    {
        LoadSettings();
    }

    private void LoadSettings()
    {
        const int DEFAULT_FPS = 30;
        const int FULLSCREEN_KEY = 0;

        var fpsValueToIndex = new Dictionary<int, int> {
            {30, 0}, {60, 1}, {120, 2}, {-1, 3}
        };

        int savedFps = PlayerPrefs.GetInt("fps", DEFAULT_FPS);
        fpsCurrentText.SetText("Current:"+savedFps);
        ApplyFpsSettings(savedFps, fpsValueToIndex);

        bool isFullscreen = PlayerPrefs.GetInt("screen", FULLSCREEN_KEY) == FULLSCREEN_KEY;
        windowCurrentText.SetText("Current:"+isFullscreen);
        ApplyScreenSettings(isFullscreen);
    }

    private void ApplyFpsSettings(int targetFps, Dictionary<int, int> fpsMap)
    {
        try 
        {
            ChangeFps(targetFps);
        }
        catch (ArgumentException)
        {
            targetFps = 30;
            ChangeFps(targetFps);
        }
        SetFpsSave(targetFps);
        int targetIndex = fpsMap.ContainsKey(targetFps) ? fpsMap[targetFps] : fpsMap[-1];
        SafelySetToggle(fpsToggleList, targetIndex, nameof(fpsToggleList));
    }

    public void SetFpsSave(int targetFps)
    {
        PlayerPrefs.SetInt("fps", targetFps);
    }

    private void ApplyScreenSettings(bool isFullscreen)
    {
        ChangeFullscreen(isFullscreen);

        int targetIndex = isFullscreen ? 0 : 1;
        SetScreenSave(targetIndex);
        SafelySetToggle(windowToggleList, targetIndex, nameof(windowToggleList));
    }

    public void SetScreenSave(int targetIndex)
    {
        PlayerPrefs.SetInt("screen", targetIndex);
    }

    private void SafelySetToggle(List<Toggle> toggleList, int index, string context)
    {
        if (index < 0 || index >= toggleList.Count) return;

        toggleList.ForEach(t => t.SetIsOnWithoutNotify(false));
        toggleList[index].SetIsOnWithoutNotify(true);
    }

    public void ChangeFps(int frame)
    {
        Application.targetFrameRate = frame;
    }

    public void ChangeFullscreen(bool screenMode)
    {
        if (screenMode)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.SetResolution(1920, 1080, false);
        }
    }
}