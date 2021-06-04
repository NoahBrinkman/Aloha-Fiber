using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum QuestionCatagories{ 
RoutePlanning,
AlarmHerkenning,
IcoonHerkenning,
Overig
}


public class Question : GamePrompt
{
    [SerializeField] private QuestionManager questionmanager = null;
    [SerializeField] private TMP_Text promptText = null;
    [SerializeField, TextArea] private string question = string.Empty, 
        correctAnswerPrompt = string.Empty, 
        incorrectAnswerPrompt = String.Empty;

    [SerializeField] private List<GameObject> promptObjects = new List<GameObject>();

    private void OnEnable()
    {
        promptText.text = question;
        promptObjects.ForEach(o => o.SetActive(false));
    }

    public void CorrectAnswerChosen()
    {
        if(isLocked) return;
        
        completed = true;
        isLocked = true;
        questionmanager.AddPointsForCorrectAnswer();
        StartCoroutine(ShowPromptBeforeReset(correctAnswerPrompt, 5));

    }

    public void IncorrectAnswerChosen()
    {
        if(isLocked) return;
        completed = true;
        StartCoroutine(ShowPromptBeforeReset(incorrectAnswerPrompt, 5));
    }
    
    IEnumerator ShowPromptBeforeReset(string _promptText, float _time)
    {
        isLocked = true;
        promptText.text = _promptText;
        promptObjects.ForEach(o => o.SetActive(true));
        yield return new WaitForSeconds(_time);
        promptText.text = question;
        if (completed)
        {
            questionmanager.NextQuestion();
        }

        isLocked = false;
    }
    
}
