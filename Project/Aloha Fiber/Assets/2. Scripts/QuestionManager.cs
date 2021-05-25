using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private int correctAnswerPointReward = 100;
    [SerializeField] private List<Question> questions = new List<Question>();
    [SerializeField] private float timePoints = 300;
    private float timer = 0;
    public int QuestionTotal => questions.Count;
    private int currentIndex = 0;
    public int CurrentIndex => currentIndex;
    private ScoreManager scoreManager = null;
    
    private void OnEnable()
    {
        timer = timePoints;
        questions.ForEach(x => x.gameObject.SetActive(false));
        questions[0].gameObject.SetActive(true);
    }

    private void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    public void NextQuestion()
    {
        if(questions.All(x => x.completed))
        {
            //add timer points
            if (timer >= 0)
            {
                scoreManager.currentProfile.score += Mathf.RoundToInt(timer);
            }
            SceneManager.LoadScene(2);
            return;
        }
        if((currentIndex + 1) >= questions.Count) return;
        
        questions[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        questions[currentIndex].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (!questions[currentIndex].lockQuestion && timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void AddPointsForCorrectAnswer()
    {
        scoreManager.currentProfile.score += correctAnswerPointReward;
    }
}
