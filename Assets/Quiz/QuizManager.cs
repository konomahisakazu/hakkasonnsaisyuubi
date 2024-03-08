using UnityEngine;
using System.Collections;
using UnityEngine.UI;//UI オブジェクトを扱う時は必須
public class QuizManager : MonoBehaviour {
    
    //他のスクリプトからも参照可能な変数宣言
    public static int g_quiznum;
    
    //アタッチしたオブジェクトが呼ばれた時に実行される。
    void Start () {
        QTextSet ();
        AnswerLabelSet ();
        ImageSet();
        TitleSet();
    }
 
    private void QTextSet(){
        //問題文を配列に代入
        string[] q_arr = new string[]
        {
            "Q1-1.何をする？",
            "Q1-2.この溶液に含まれる金属イオンは何？",
            "Q2-1.濾過後、何をする？",
            "Q2-2.この溶液に含まれる金属イオンは何？",
            "Q3-1.濾過＆煮沸後、何をする？",
            "Q3-2.何をする？",
            "Q3-3.この溶液に含まれる金属イオンは何？",
            "Q4-1.濾過後、何をする？",
            "Q4-2.この溶液に含まれる金属イオンは何？",
            "Q5-1.濾過後、何をする？",
            "Q5-2.この溶液に含まれる金属イオンは何？",
            "赤い炎が出た。この元素は何？",
            "黄緑の炎が出た。この元素は何？",
            "紫の炎が出た。この元素は何？",
            "",
            "",
            "",
            "",
            "",
        };
        
        //特定の名前のオブジェクトを検索してアクセス
        Text QText = GameObject.Find("Quiz/QText").GetComponentInChildren<Text> ();
        //データをセットすることで、既存情報を上書きできる
        QText.text = q_arr[g_quiznum];
    }
    
    private void  AnswerLabelSet(){
        //回答文面の作成
        string[] array = new string[]
        {
            "希塩酸を加える","希硝酸を加える","希硫酸を加える","加熱する",
            "銅(Ⅱ)イオン","亜鉛(Ⅲ)イオン","銀イオン","ナトリウムイオン",
            "硫化水素を通じる","アンモニア水溶液を加える","加熱する","希硝酸を加える",
            "ナトリウムイオン","銅(Ⅱ)イオン","鉄(Ⅲ)イオン","カルシウムイオン",
            "硫化水素を加える","アンモニア水を加える","加熱する","硝酸を加える",
            "希塩酸を加える","酢酸を加える","硫化水素を通じる","アンモニア水を過剰に加える",
            "アルミニウムイオン","銀イオン","鉄(Ⅲ)イオン","ナトリウムイオン",
            "硫化水素を通じる","濃硫酸を加える","加熱する","アンモニアを通じる",
            "アルミニウムイオン","鉄(Ⅱ)イオン","亜鉛(Ⅱ)イオン","マグネシウムイオン",
            "酢酸を加える","炭酸アンモニウム溶液を加える","濃硫酸を加える","加熱する",
            "マグネシウムイオン","カルシウムイオン","リチウムイオン","ナトリウムイオン",
            "カリウム","マグネシウム","カルシウム","リチウム",
            "バリウム","ナトリウム","銅","ストロンチウム",
            "カルシウム","ストロンチウム","カリウム","ナトリウム",
            "C4H4O2","C3H8O","C2H2O","C8H10O",
            "C2H2O","C3H8O","C4H4O2","C8H10O",
            "C4H4O2","C3H8O","C6H12O","C8H12O",
            "C4H6O2","C8H10O","C2H2O","C3H8O",
        };
        //ボタンが4つあるのでそれぞれ代入
        for (int i = g_quiznum * 4 + 1; i <= g_quiznum * 4 + 4 ; i++){
            Text ansLabel = GameObject.Find("Quiz/AnsButton" + (i - g_quiznum * 4)).GetComponentInChildren<Text> ();
            ansLabel.text = array[i-1];
        }
    }
    
    private void ImageSet(){
        //現在描画している画像を取得
        SpriteRenderer judgeImage = GameObject.Find ("Quiz/QImage").GetComponent<SpriteRenderer> ();
        //Resourcesから指定した名前の画像データをロード
        Sprite loadingImage = Resources.Load<Sprite> ("QImage" + (g_quiznum + 1));
        //画像を置換
        judgeImage.sprite = loadingImage;
    }
    
    private void TitleSet(){
        //問題文を配列に代入
        string[] t_arr = new string[]
        {
            "ー 金属イオンの分析１ ー",
            "ー 金属イオンの分析１ ー",
            "ー 金属イオンの分析２ ー",
            "ー 金属イオンの分析２ ー",
            "ー 金属イオンの分析３ ー",
            "ー 金属イオンの分析３ ー",
            "ー 金属イオンの分析３ ー",
            "ー 金属イオンの分析４ ー",
            "ー 金属イオンの分析４ ー",
            "ー 金属イオンの分析５ ー",
            "ー 金属イオンの分析５ ー",
            "ー 炎色反応１ ー",
            "ー 炎色反応２ ー",
            "ー 炎色反応３ ー",
            "ー 元素分析１ ー",
            "ー 元素分析１ ー",
            "ー 元素分析２ ー",
            "ー 元素分析２ ー",
        };
        
        //特定の名前のオブジェクトを検索してアクセス
        Text TitleText = GameObject.Find("Quiz/TitleText").GetComponentInChildren<Text> ();
        //データをセットすることで、既存情報を上書きできる
        TitleText.text = t_arr[g_quiznum];
    }
    
    public static  void Countquiznum(string judgeData){
        if(judgeData=="正解")
        g_quiznum++;
    }
}