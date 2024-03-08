using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class ResultManager : MonoBehaviour {
    //他のスクリプトからも参照可能な変数宣言
    public static string g_judgeData;
 
    void Start ()
    {
        //正解後のテキストを配列に代入
        string[] atext_arr = new string[]
        {
            "白色沈殿が生成された！",
            "正解！",
            "黒色沈殿が生成された！",
            "正解！",
            "溶液が黄褐色に変わった！",
            "赤褐色沈殿が生成された！",
            "正解！",
            "白色沈殿が生成された！",
            "正解！",
            "白色沈殿が生成された！",
            "正解！\nバーナーが使えるようになった！" ,
            "正解！",
            "正解！",
            "正解！\n元素分析装置が使えるようになった！",
            "正解！",
            "正解！",
            "正解！",
            "正解！",
        };
        
        //デフォルトは不正解、正解なら画像と文言を切り替える
        if (g_judgeData == "正解") {
            //現在描画している画像を取得
            SpriteRenderer judgeImage = GameObject.Find ("JudgeUI/JudgeImage").GetComponent<SpriteRenderer> ();
            //Resourcesから指定した名前の画像データをロード
            Sprite loadingImage = Resources.Load<Sprite> ("mark_maru");
            //画像を置換
            judgeImage.sprite = loadingImage;
            //表示テキストを取得して置換
            Text judgeLabel =  GameObject.Find("JudgeUI/JudgeLabel").GetComponent<Text>();
            judgeLabel.text = atext_arr[QuizManager.g_quiznum];
        }
        //問題の進行
        QuizManager.Countquiznum(g_judgeData);
    }
 
    //他のスクリプトからも参照可能な関数宣言
    public static  void SetJudgeData(string judgeData){
        g_judgeData = judgeData;
    }
}