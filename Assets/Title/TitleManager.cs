using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void  NextScene(){
        //今いるシーンがTitleという名前であれば、Mapという名前のシーンに移動する
        if (Application.loadedLevelName == "Title") {
            Application.LoadLevel ("Map");
        }
    }
}
