using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField] private QuestionManager questionmanager = null;
    public bool completed = false;
    [SerializeField] private Text promptText = null;
    [SerializeField, TextArea] private string question = string.Empty, 
        correctAnswerPrompt = string.Empty, 
        incorrectAnswerPrompt = String.Empty;

    public bool lockQuestion = false;

    private void OnEnable()
    {
        promptText.text = question;
    }

    public void CorrectAnswerChosen()
    {
        if(lockQuestion) return;
        
        completed = true;
        lockQuestion = true;
        StartCoroutine(ShowPromptBeforeReset(correctAnswerPrompt, 5));

    }

    public void IncorrectAnswerChosen()
    {
        if(lockQuestion) return;
        
        StartCoroutine(ShowPromptBeforeReset(incorrectAnswerPrompt, 5));
    }
    
    IEnumerator ShowPromptBeforeReset(string _promptText, float _time)
    {
        lockQuestion = true;
        promptText.text = _promptText;
        yield return new WaitForSeconds(_time);
        promptText.text = question;
        if (completed)
        {
            questionmanager.NextQuestion();
        }

        lockQuestion = false;
    }
    
}
