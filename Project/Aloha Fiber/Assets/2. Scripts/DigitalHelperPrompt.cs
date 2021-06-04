using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DigitalHelperPrompt : GamePrompt
{
    [SerializeField] private QuestionManager questionManager = null;
    [SerializeField] private TMP_Text promptText = null;
    [SerializeField, TextArea] private List<String> textPrompts = new List<string>();
    [SerializeField] private Button textGraphic = null;
    private int index = 0;
    private void OnEnable()
    {
        textGraphic.onClick.RemoveAllListeners();
        textGraphic.onClick.AddListener(NextSlide);
        isLocked = true;
    }

    private void NextSlide()
    {
        if ((index + 1) >= textPrompts.Count) Complete();
        index++;
        promptText.text = textPrompts[index];

    }

    private void Complete()
    {
        completed = true;
        questionManager.NextQuestion();
    }
    
}
