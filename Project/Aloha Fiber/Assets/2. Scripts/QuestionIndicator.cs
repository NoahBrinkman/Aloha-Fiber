using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class QuestionIndicator : MonoBehaviour
{
    [SerializeField] private QuestionManager questionManager = null;
    private Text text = null;

    private void OnEnable()
    {
        text = GetComponent<Text>();
    }


    private void Update()
    {
        text.text = $"Vraag: {questionManager.CurrentIndex + 1}/{questionManager.QuestionTotal}";
    }
}
