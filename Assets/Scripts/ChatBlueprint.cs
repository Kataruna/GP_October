using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chat/Blueprint")]
public class ChatBlueprint : ScriptableObject
{
    public ChatDetail[] dialogues;
}

[System.Serializable]
public class ChatDetail
{
    public string speakerName;
    [TextArea(10,10)] public string message;
}
