using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void  NextScene(){
        //今いるシーンがQuizという名前であれば、Hintという名前のシーンに移動する
        if (Application.loadedLevelName == "Quiz") {
            Application.LoadLevel ("Hint");
        }
        //今いるシーンがHintという名前であれば、Quizという名前のシーンに移動する
        if (Application.loadedLevelName == "Hint") {
            Application.LoadLevel ("Quiz");
        }
    }
}