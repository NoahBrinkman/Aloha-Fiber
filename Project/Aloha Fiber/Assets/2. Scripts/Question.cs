using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum QuestionCatagories{ 
RoutePlanning,
AlarmHerkenning,
IcoonHerkenning,
Overig
}


public class Question : MonoBehaviour
{
    public QuestionCatagories catagory = QuestionCatagories.Overig;
    
    [SerializeField] private QuestionManager questionmanager = null;
    public bool completed = false;
    [SerializeField] private Text promptText = null;
    [SerializeField, TextArea] private string question = string.Empty, 
        correctAnswerPrompt = string.Empty, 
        incorrectAnswerPrompt = String.Empty;

    [HideInInspector] public bool lockQuestion = false;

    private void OnEnable()
    {
        promptText.text = question;
    }

    public void CorrectAnswerChosen()
    {
        if(lockQuestion) return;
        
        completed = true;
        lockQuestion = true;
        questionmanager.AddPointsForCorrectAnswer();
        StartCoroutine(ShowPromptBeforeReset(correctAnswerPrompt, 5));

    }

    public void IncorrectAnswerChosen()
    {
        if(lockQuestion) return;
        completed = true;
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
