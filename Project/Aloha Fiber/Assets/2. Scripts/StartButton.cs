using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput = null;
    private ScoreManager scoreManager = null;
    private Button button = null;
    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClicked);
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        button.interactable = !(nameInput.text == String.Empty);
    }

    private void OnClicked()
    {
        if (nameInput.text != string.Empty)
        {
            Profile newProfile = new Profile();
            newProfile.name = nameInput.text;
            newProfile.scores = new List<Score>();
            foreach (QuestionCatagories catagory in Enum.GetValues(typeof(QuestionCatagories)))
            {
                Score newScore = new Score();
                newScore.catagory = catagory;
                newScore.scoreAmount = 0;
                newProfile.scores.Add(newScore);
            }
            
            scoreManager.currentProfile = newProfile;
            scoreManager.scoreboard.Add(newProfile);
        }
        SceneManager.LoadScene(1);
    }
}
