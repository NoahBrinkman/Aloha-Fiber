using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Profile
{
    public string name = String.Empty;
    public List<Score> scores = new List<Score>();
    public int scoreSum => scores.Sum(s => s.scoreAmount);
}

[Serializable]
public class Score
{
    public int scoreAmount = 0;
    public QuestionCatagories catagory = QuestionCatagories.Overig;
}

public class ScoreManager : MonoBehaviour
{
    public List<Profile> scoreboard = new List<Profile>();
    public Profile currentProfile = null;
    public int maxScore = 600;
    
    
    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void SortScores()
    {
        scoreboard = scoreboard.OrderByDescending(x => x.scoreSum).ToList();
    }
    
}
