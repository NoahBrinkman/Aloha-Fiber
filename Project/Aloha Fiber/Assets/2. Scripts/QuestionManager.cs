using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private int CorrectAnswerPointReward = 100;
    [SerializeField] private List<Question> questions = new List<Question>();
    public int QuestionTotal => questions.Count;
    private int currentIndex = 0;
    public int CurrentIndex => currentIndex;
    private ScoreManager scoreManager = null;
    
    private void OnEnable()
    {
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
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else 
            Application.Quit();
            #endif
        }
    }

    public void AddPointsForCorrectAnswer()
    {
        scoreManager.currentProfile.score += CorrectAnswerPointReward;
    }
}
