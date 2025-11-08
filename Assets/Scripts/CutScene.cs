using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CutSceneStart());
    }
    IEnumerator CutSceneStart()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        SceneManager.LoadScene("MainScene");
    }
}
