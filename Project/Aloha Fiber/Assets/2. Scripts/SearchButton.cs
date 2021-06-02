using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SearchButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField searchField = null;
    [SerializeField] private TMP_Text searchResultText = null;
    private Button button = null;
    private ScoreManager scoreManager = null;
    private void OnEnable()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(DisplaySearchResult);
    }

    private void Update()
    {
        button.interactable = !(searchField.text == String.Empty);
    }

    private void DisplaySearchResult()
    {
        searchResultText.text = string.Empty;
        List<Profile> searchresults = scoreManager.scoreboard.Where(x => x.name.ToLower().Contains(searchField.text.ToLower())).ToList();
        for (int i = 0; i < searchresults.Count; i++)
        {
            if (i == 0)
            {
                searchResultText.text =
                    $"#{scoreManager.scoreboard.IndexOf(searchresults[i]) + 1} {searchResultText.text}{searchresults[i].name} - {searchresults[i].scoreSum}/{scoreManager.maxScore}";
                for (int j = 0; j < searchresults[i].scores.Count; j++)
                {

                    searchResultText.text =
                        $"{searchResultText.text}\n<size=9>{searchresults[i].scores[j].catagory} - {searchresults[i].scores[j].scoreAmount}</size>";
                }
            }
            else
            {
                searchResultText.text =
                    $"{searchResultText.text}\n#{scoreManager.scoreboard.IndexOf(searchresults[i]) + 1} {searchresults[i].name} - {searchresults[i].scoreSum}/{scoreManager.maxScore}";
                for (int j = 0; j < searchresults[i].scores.Count; j++)
                {
                    searchResultText.text =
                        $"{searchResultText.text}\n<size=9>{searchresults[i].scores[j].catagory} - {searchresults[i].scores[j].scoreAmount}</size>";
                }
            }
        }
    }
    
}
