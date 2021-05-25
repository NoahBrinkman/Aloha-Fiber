using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreBoard : MonoBehaviour
{
    private TMP_Text text = null;
    private ScoreManager scoreManager = null;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        scoreManager.SortScores();
        if (scoreManager.scoreboard.Count <= 10)
        {
            for (int i = 0; i < scoreManager.scoreboard.Count; i++)
            {
                if (i == 0)
                    text.text =
                        $"{text.text}#{i + 1} {scoreManager.scoreboard[i].name} - {scoreManager.scoreboard[i].score}/{scoreManager.maxScore}";
                else
                    text.text =
                        $"{text.text}\n#{i + 1} {scoreManager.scoreboard[i].name} - {scoreManager.scoreboard[i].score}/{scoreManager.maxScore}";
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                    text.text =
                        $"{text.text}#{i + 1} {scoreManager.scoreboard[i].name} - {scoreManager.scoreboard[i].score}/{scoreManager.maxScore}";
                else
                    text.text =
                        $"{text.text}\n#{i + 1} {scoreManager.scoreboard[i].name} - {scoreManager.scoreboard[i].score}/{scoreManager.maxScore}";
            } 
        }
    }

}
