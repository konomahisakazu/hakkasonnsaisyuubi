using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        if (QuizManager.g_quiznum > 10 && QuizManager.g_quiznum <= 13) {
            //現在描画している画像を取得
            SpriteRenderer HintImage = GameObject.Find("HintUI/Hint1").GetComponent<SpriteRenderer>();
            //Resourcesから指定した名前の画像データをロード
            Sprite loadingImage = Resources.Load<Sprite>("Hint2");
            //画像を置換
            HintImage.sprite = loadingImage;
        } else if (QuizManager.g_quiznum > 13) {
            //現在描画している画像を取得
            SpriteRenderer HintImage = GameObject.Find("HintUI/Hint1").GetComponent<SpriteRenderer>();
            //Resourcesから指定した名前の画像データをロード
            Sprite loadingImage = Resources.Load<Sprite>("Hint3");
            //画像を置換
            HintImage.sprite = loadingImage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
