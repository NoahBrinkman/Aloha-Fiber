using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private int correctAnswerPointReward = 100;
    [SerializeField] private List<GamePrompt> prompts = new List<GamePrompt>();
    [SerializeField] private float timePoints = 300;
    private float timer = 0;
    private int currentIndex = 0;
    public int CurrentIndex => currentIndex;
    public int QuestionsTotal => prompts.Count;
    private ScoreManager scoreManager = null;
    
    private void OnEnable()
    {
        timer = timePoints;
        prompts.ForEach(x => x.gameObject.SetActive(false));
        prompts[0].gameObject.SetActive(true);
    }

    private void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    public void NextQuestion()
    {
        if(prompts.All(x => x.completed))
        {
            //add timer points
            if (timer >= 0)
            {
                scoreManager.currentProfile.scores[scoreManager.currentProfile.scores.FindIndex(x => x.catagory == QuestionCatagories.Overig)].scoreAmount += Mathf.RoundToInt(timer);
            }
            SceneManager.LoadScene(2);
            return;
        }
        if((currentIndex + 1) >= prompts.Count) return;
        
        prompts[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        prompts[currentIndex].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (!prompts[currentIndex].isLocked && timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void AddPointsForCorrectAnswer()
    {
        scoreManager.currentProfile.scores[scoreManager.currentProfile.scores.FindIndex(x => x.catagory == prompts[currentIndex].catagory)].scoreAmount += correctAnswerPointReward;
    }
}
