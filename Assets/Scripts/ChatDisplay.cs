using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatDisplay : MonoBehaviour
{
    [SerializeField] private ChatBlueprint activeChat;
    [SerializeField] private TMP_Text chatDisplay;
    [SerializeField, Range(0f, 0.1f)] private float textSpeed;

    private int _line;

    private void Start()
    {
        StartChat();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChatInteraction();
        }
    }

    void StartChat()
    {
        _line = 0;

        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        _line += 1;

        if (_line < activeChat.dialogues.Length)
        {
            StartCoroutine(TypeLine());
        }
    }

    void ChatInteraction()
    {
        if (_line == activeChat.dialogues.Length - 1 && chatDisplay.text == activeChat.dialogues[_line].message)
        {
            ConversationEnd();
        }
        else if (chatDisplay.text == activeChat.dialogues[_line].message)
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            chatDisplay.text = activeChat.dialogues[_line].message;
        }
    }

    void ConversationEnd()
    {
        Debug.Log("End of the line");
    }

    IEnumerator TypeLine()
    {
        chatDisplay.text = String.Empty;

        foreach (char c in activeChat.dialogues[_line].message)
        {
            chatDisplay.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}


