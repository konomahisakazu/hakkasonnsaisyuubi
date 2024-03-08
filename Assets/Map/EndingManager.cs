using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    //パラメータ
    private const char SEPARATE_MAIN_START = '「';
    private const char SEPARATE_MAIN_END = '」';
    private const char SEPARATE_PAGE = '&';
    private Queue<string> _pageQueue;

    private Queue<char> _charQueue;
    [SerializeField] private Text mainText;
    [SerializeField] private Text nameText;
    [SerializeField] private string nextSceneName;

    private string _text =
        "???「矢口ちゃんと矢口君が異世界に迷い込んでから数か月が経過した。」 &???「彼らは実験室での日々を送りながら元素に関する知識を身につけ、爆発の原因を突き止めるべく実験を重ねた。」 &???「ある日、彼らは実験の結果、爆発の原因は実験室で使用されていた化合物がごく稀に反応することで起こる事象だと気が付いた。」 &矢口ちゃん「ということは、この反応がもう一度起これば脱出できるんじゃない！？」 &矢口くん「なるほど、試してみる価値はありそうだね。」 &矢口くん「これを混ぜて......」 &???「こうして、彼らは発見した事実を元の世界に戻る手がかりとし、」 &???「ついには元いた世界へ戻ることが出来たのだった。」";

    [SerializeField] private float captionSpeed = 0.2f;

    //文を1文字ごとに区切り、キューに格納したものを返す
    private Queue<char> SeparateString(string str)
    {
        // 文字列をchar型の配列にする = 1文字ごとに区切る
        char[] chars = str.ToCharArray();
        Queue<char> charQueue = new Queue<char>();
        // foreach文で配列charsに格納された文字を全て取り出し
        // キューに加える
        foreach (char c in chars) charQueue.Enqueue(c);
        return charQueue;
    }

    //1文字を出力する
    private bool OutputChar()
    {
        // キューに何も格納されていなければfalseを返す
        if (_charQueue.Count <= 0) return false;
        mainText.text += _charQueue.Dequeue();
        return true;
    }

    //文字送りするコルーチン
    private IEnumerator ShowChars(float wait)
    {
        // OutputCharメソッドがfalseを返す(=キューが空になる)までループする
        while (OutputChar())
            // wait秒だけ待機
            yield return new WaitForSeconds(wait);
        // コルーチンを抜け出す
        yield break;
    }

    //全文を表示する
    private void OutputAllChar()
    {
        // コルーチンをストップ
        StopCoroutine(ShowChars(captionSpeed));
        // キューが空になるまで表示
        while (OutputChar()) ;
    }

    //クリックしたときの処理
    private void OnClick()
    {
        if (_charQueue.Count > 0) OutputAllChar();
        else
        {
            if (!ShowNextPage())
            {
                SceneManager.LoadScene(nextSceneName); // シーン移動
            }   
        }
    }

    // MonoBehaviourを継承している場合限定で
    // 毎フレーム呼ばれる
    private void Update()
    {
        // 左(=0)クリックされたらOnClickメソッドを呼び出し
        if (Input.GetMouseButtonDown(0)) OnClick();
    }

    //文字列を指定した区切り文字ごとに区切り、キューに格納したものを返す
    private Queue<string> SeparateString(string str, char sep)
    {
        string[] strs = str.Split(sep);
        Queue<string> queue = new Queue<string>();
        foreach (string l in strs) queue.Enqueue(l);
        return queue;
    }

    //初期化する
    private void Init()
    {
        _pageQueue = SeparateString(_text, SEPARATE_PAGE);
        ShowNextPage();
    }

    //次のページを表示する
    private bool ShowNextPage()
    {
        if (_pageQueue.Count <= 0)
        {
            SceneManager.LoadScene(nextSceneName); // ここでシーンを移動する
            return false;
        }
        ReadLine(_pageQueue.Dequeue());
        return true;
    }

    private void Start()
    {
        Init();
    }

    private void ReadLine(string text)
    {
        string[] ts = text.Split(SEPARATE_MAIN_START);
        string name = ts[0];
        string main = ts[1].Remove(ts[1].LastIndexOf(SEPARATE_MAIN_END));
        nameText.text = name;
        mainText.text = "";
        _charQueue = SeparateString(main);
        // コルーチンを呼び出す
        StartCoroutine(ShowChars(captionSpeed));
    }
}