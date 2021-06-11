using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TextPrompt
{
    [TextArea] public String text = String.Empty;
    public Sprite face = null;
}

public class DigitalHelperPrompt : GamePrompt
{
    [SerializeField] private QuestionManager questionManager = null;
    [SerializeField] private TMP_Text promptText = null;
    [SerializeField] private List<TextPrompt> textPrompts = new List<TextPrompt>();
    [SerializeField] private Button textGraphic = null;
    [SerializeField] private Image face = null;
    private int index = 0;
    private void OnEnable()
    {
        textGraphic.onClick.RemoveAllListeners();
        textGraphic.onClick.AddListener(NextSlide);
        promptText.text = textPrompts[index].text;
        face.sprite = textPrompts[index].face;
        isLocked = true;
    }

    private void NextSlide()
    {
        if ((index + 1) >= textPrompts.Count)
        {
            Complete();
            return;
        }
        index++;
        promptText.text = textPrompts[index].text;
        face.sprite = textPrompts[index].face;
    }

    private void Complete()
    {
        completed = true;
        questionManager.NextQuestion();
    }
    
}
