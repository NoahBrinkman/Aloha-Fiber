using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private List<Question> questions = new List<Question>();
    private int currentIndex = 0;
    
    private void OnEnable()
    {
        questions.ForEach(x => x.gameObject.SetActive(false));
        questions[0].gameObject.SetActive(true);
    }

    public void NextQuestion()
    {
        if(questions.All(x => x.completed))
        {
            print("You win");
            return;
        }
        if((currentIndex + 1) >= questions.Count) return;
        
        questions[currentIndex].gameObject.SetActive(false);
        currentIndex++;
        questions[currentIndex].gameObject.SetActive(true);
    }

}
