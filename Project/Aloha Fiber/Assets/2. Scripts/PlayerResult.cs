using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PlayerResult : MonoBehaviour
{
    [TextArea,SerializeField] private string defaultInput = String.Empty; 
    private TMP_Text text = null;
    private ScoreManager scoreManager = null;
    private void Start()
    {
        text = GetComponent<TMP_Text>();
        
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        if (scoreManager.currentProfile.name == String.Empty) text.text = defaultInput;
        else text.text = $"#{scoreManager.scoreboard.IndexOf(scoreManager.currentProfile) + 1} {scoreManager.currentProfile.name} - {scoreManager.currentProfile.score}/{scoreManager.maxScore}";
    }
}
