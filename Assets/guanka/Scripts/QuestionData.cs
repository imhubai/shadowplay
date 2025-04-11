using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// QuestionData答题系统
/// answer 1234
/// </summary>
[System.Serializable]
public class QuestionData
{
    public string question;
    public string contentA;
    public string contentB;
    public string contentC;
    public string contentD;
    public int answer;
}

[System.Serializable]
public class QuestionList
{
    public List<QuestionData> questionItems;
}