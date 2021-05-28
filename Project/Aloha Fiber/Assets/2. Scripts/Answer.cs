using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Answer : MonoBehaviour
{
    private Button button = null;
    [SerializeField] private bool correctAnswer = false;
    [SerializeField] private Question question = null;
    
    private void OnEnable()
    {
        button = GetComponent<Button>();
        if(correctAnswer) button.onClick.AddListener(question.CorrectAnswerChosen);
        else button.onClick.AddListener(question.IncorrectAnswerChosen);
    }

    private void OnValidate()
    {
        if (correctAnswer) transform.name = "CorrectAnswer";
        else transform.name = "IncorrectAnswer";
    }
}
