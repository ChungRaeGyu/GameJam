using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class WinPanel : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float num = 0;
    bool check = true;
    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            num += Time.deltaTime;
        }
        else
        {
            num -= Time.deltaTime;
        }
        if(num>=1f||num<=0f)
        {
            check = !check;
        }
        text.color = new Color(text.color.r, text.color.g, text.color.b, num);
    }

    private void Start()
    {
        StartCoroutine(GameIsOver());
    }

    public void TestGameOver()
    {
        StartCoroutine(GameIsOver());
    }
    IEnumerator GameIsOver()
    {
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        DataManager.Instance.stage = 2;
        SceneManager.LoadScene("CutScene");
    }
}
