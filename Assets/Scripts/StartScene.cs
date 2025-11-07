using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("MainScene");
    }
}
