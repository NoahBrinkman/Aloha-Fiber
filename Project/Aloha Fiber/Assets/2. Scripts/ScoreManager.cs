using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Profile
{
    public string name = String.Empty;
    public int score = 0;
}

public class ScoreManager : MonoBehaviour
{
    public List<Profile> scoreboard = new List<Profile>();

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            scoreboard = scoreboard.OrderByDescending(o=>o.score).ToList();
        }
    }
}
