using System.Collections.Generic;

/// <summary>
/// speech
/// </summary>
[System.Serializable]
public class SpeechLevel
{
    public string answerCn;
    public string textPinyin;
    public string answerFileName;
}

[System.Serializable]
public class SpeechList
{
    public List<SpeechLevel> speechItems;
}