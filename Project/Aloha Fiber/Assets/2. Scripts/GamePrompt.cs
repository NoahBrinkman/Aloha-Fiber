using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePrompt : MonoBehaviour
{
   [HideInInspector] public bool isLocked = false;
    public bool completed = false;
    public QuestionCatagories catagory = QuestionCatagories.Overig;
}
