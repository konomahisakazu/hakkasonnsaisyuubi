using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public void NextQuiz(){
 
        if (QuizManager.g_quiznum == 18) {
            Application.LoadLevel ("Map3");
        }
        else
        {
            Application.LoadLevel ("Quiz");
        }
    }
}
