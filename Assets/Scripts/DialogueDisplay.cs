using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueDisplay : MonoBehaviour
{
    [SerializeField] private DialogueBlueprint activeDialogue;
    [SerializeField] private TMP_Text messageDisplay;
    [SerializeField] private float textSpeed;
    
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

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        _line += 1;
        
        if (_line < activeDialogue.dialogues.Length)
        {
            StartCoroutine(TypeLine());
        }
    }

    void DialogueInteraction()
    {
        if(_line == activeDialogue.dialogues.Length - 1 && messageDisplay.text == activeDialogue.dialogues[_line].Message)
            ConversationEnd();
        else if(messageDisplay.text == activeDialogue.dialogues[_line].Message) NextLine();
        else
        {
            StopAllCoroutines();
            messageDisplay.text = activeDialogue.dialogues[_line].Message;
        }
    }

    void ConversationEnd()
    {
        Debug.Log("End of all Line");
    }

    IEnumerator TypeLine()
    {
        messageDisplay.text = String.Empty; // ""

        foreach (char c in activeDialogue.dialogues[_line].Message)
        {
            messageDisplay.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

