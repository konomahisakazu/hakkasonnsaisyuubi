using UnityEngine;
using UnityEngine.SceneManagement;

public class click : MonoBehaviour
{
    public void change_scene()
    {
        SceneManager.LoadScene("Quiz");
    }
}