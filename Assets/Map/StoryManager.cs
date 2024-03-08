using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
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
        "大学にて「20XX年X月X日」 &大学にて「ドカーン!!!!」&矢口くん「な、何が起きたんだ…？」&矢口ちゃん「（目をこすりながら）私も分からない…」&矢口ちゃん「あれ、私たち、どこかに吸い込まれた？」&矢口ちゃん「ここ、どこなんだろう？」&矢口ちゃん「私たち、大学にいたはずなのに。」&矢口くん「もしかして、異世界転移ってやつか…？」&矢口ちゃん「分からない…」&矢口ちゃん「なんかここって見覚えあるような…」&矢口くん「実験室みたいだけど、こんな場所にいるはずがない。」&矢口ちゃん「でも、周りを見て。」&矢口ちゃん「これって、私たちの学校の実験室に似てるんじゃない？」&矢口くん「そうだね、確かに。」&矢口くん「でも、こんなに広い実験室はなかったし…」&矢口くん「あ、でも！あれを見て！」&矢口ちゃん「......なんだろう、謎の器具がいっぱいあるね」&矢口くん「もしかして、あの器具が原因で爆発が起きたのか…？」&矢口ちゃん「そうかも知れないね。」&矢口ちゃん「でも、これってどうやって元の世界に戻るの？」&矢口くん「うーん、分からないけど、まずはあの爆発の原因を突き止めないといけない。」&矢口ちゃん「爆発の原因が分かったら元の世界に戻る方法もきっと分かると思う！」&矢口くん「爆発の調査をするにはもっと元素について詳しくならないとだな。」&矢口ちゃん「じゃあ、私たち、元素の達人になるしかないね。」&矢口くん「そうだね、頑張ろう。」&???「元素の知識をつけるために、最初に実験をしてみよう！」&???「まず、実験台にある試験管をタップして、未知試料に含まれる陽イオンを特定しよう！」";

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