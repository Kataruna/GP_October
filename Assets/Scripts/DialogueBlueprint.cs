using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Conversation/Dialogue Blueprint")]
public class DialogueBlueprint : ScriptableObject
{
    public DialogueTemplate[] dialogues;
}

[Serializable]
public class DialogueTemplate
{
    public string SpeakerName;
    [TextArea(10,10)] public string Message;
}