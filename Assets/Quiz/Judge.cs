using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class Judge : MonoBehaviour {
 
    //選択したボタンのテキストラベルと正解のテキストを比較して正誤を判定
    public void JudgeAnswer(){
        //正解を配列に代入
        string[] a_arr = new string[]
        {
            "希塩酸を加える",
            "銀イオン",
            "硫化水素を通じる",
            "銅(Ⅱ)イオン",
            "硝酸を加える",
            "アンモニア水を過剰に加える",
            "鉄(Ⅲ)イオン",
            "硫化水素を通じる",
            "亜鉛(Ⅱ)イオン",
            "炭酸アンモニウム溶液を加える",
            "カルシウムイオン",
            "リチウム",
            "バリウム",
            "カリウム",
            "C2H2O",
            "C2H2O",
            "C3H8O",
            "C3H8O",
        };
        //選択したボタンのテキストラベルを取得する
        Text selectedBtn = this.GetComponentInChildren<Text> ();

        if (selectedBtn.text == a_arr[QuizManager.g_quiznum]) {
            //選択したデータをグローバル変数に保存
            ResultManager.SetJudgeData ("正解");
            Application.LoadLevel ("Result");
        } else {
            //選択したデータをグローバル変数に保存
            ResultManager.SetJudgeData ("不正解");
            Application.LoadLevel ("Result");
        }
    }
}