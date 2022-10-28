using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueDisplayInstant : MonoBehaviour
{
    [SerializeField] private DialogueBlueprint activeDialogue;
    [SerializeField] private TMP_Text messageDisplay;
    
    private int _line;

    private void Start()
    {
        StartConversation();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) DialogueInteraction();
    }

    void StartConversation()
    {
        _line = 0; // บทที่ 1
        
        messageDisplay.text = activeDialogue.dialogues[_line].Message;
    }

    void NextLine()
    {
        _line += 1;
        
        if (_line < activeDialogue.dialogues.Length)
        {
            messageDisplay.text = activeDialogue.dialogues[_line].Message;
        }
    }

    void DialogueInteraction()
    {
        if(_line == activeDialogue.dialogues.Length - 1) ConversationEnd();
        else if(messageDisplay.text == activeDialogue.dialogues[_line].Message) NextLine();
    }

    void ConversationEnd()
    {
        Debug.Log("End of all Line");
    }
}

