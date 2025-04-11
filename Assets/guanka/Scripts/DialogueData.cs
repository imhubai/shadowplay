using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DialogueData对话存储Json实体
/// </summary>
[System.Serializable]
public class DialogueData
{
    public string characterName;
    public string content;
    public bool hasAvatar;
    public string avatarFileName;
    public bool hasSound;
    public string soundFileName;
    public bool hasImageChange;
    public string imageFileName;
}

[System.Serializable]
public class DialogList
{
    public List<DialogueData> dialogItems;
}