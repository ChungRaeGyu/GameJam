using System.Collections;
using UnityEngine;

public class SpaceBarPanel : MonoBehaviour
{
    [SerializeField] private RectTransform leftDNA;
    [SerializeField] private RectTransform rightDNA;
    [SerializeField] private RectTransform line;

    [SerializeField] private Vector2 originLeftDNA;
    [SerializeField] private Vector2 originRightDNA;
    [SerializeField] private float speed;

    private bool over;
    [SerializeField]private float failCount;
    private void Awake()
    {
        originLeftDNA = leftDNA.anchoredPosition;
        originRightDNA = rightDNA.anchoredPosition;
    }
    private void OnEnable()
    {
        Debug.Log("ONEnable");
        Reset();
        over = true;
        failCount = 3;
        StartCoroutine(MouseClick());
    }
    IEnumerator MouseClick(){

        while (over)
        {
            yield return null;
            leftDNA.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);
            rightDNA.anchoredPosition -= new Vector2(speed * Time.deltaTime, 0);

            if(Input.GetMouseButtonDown(0))
            {
                if (line.anchoredPosition.x - 5 <= rightDNA.anchoredPosition.x && rightDNA.anchoredPosition.x <= line.anchoredPosition.x + 20)
                {
                    over = false;
                    //성공 알림 해주고 패널 조금있다가 닫기
                    //여기서 확률 조정해주기
                    Debug.Log("Success");
                    GameManager.Instance.ShowDescription("Success");
                    GameManager.Instance.spawnSystem.Spawn();
                    //소환 
                    yield return new WaitForSecondsRealtime(1f);
                    gameObject.SetActive(false);
                    GameManager.Instance.DNAManipulationPanelControl();
                    yield break;
                }
                else
                {
                    failCount--;
                    //실패 알림 해주기
                    Debug.Log($"DNA : {rightDNA.anchoredPosition.x} , Line : {line.anchoredPosition}");
                    Debug.Log("Fail " + "잘못누름");
                    Reset();
                }
            }
            else if (rightDNA.anchoredPosition.x < line.anchoredPosition.x - 10)
            {
                failCount--;
                //실패 알림 해주기
                Debug.Log("Fail " + failCount);
                Reset();
                yield return null;
            }


            if (failCount <= 0)
            {
                //완전 실패 패널 닫아버리기
                GameManager.Instance.ShowDescription("Fail");
                Debug.Log("Game Over");
                yield return new WaitForSecondsRealtime(1f);
                gameObject.SetActive(false);
                GameManager.Instance.DNAManipulationPanelControl();
                over = false;
            }
        }
    }

/*    private void Update()
    {
        //나중에 코루틴으로 쓰는 편이 좋겠다.
        if (over) return;
        leftDNA.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);
        rightDNA.anchoredPosition -= new Vector2(speed * Time.deltaTime, 0);
        if (rightDNA.anchoredPosition.x < line.anchoredPosition.x - 5) 
        {
            failCount--;
            //실패 알림 해주기
            Debug.Log("Fail " + failCount);
            Reset();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (line.anchoredPosition.x - 5 <= rightDNA.anchoredPosition.x && rightDNA.anchoredPosition.x <= line.anchoredPosition.x +5)
            {
                //성공 알림 해주고 패널 조금있다가 닫기
                //여기서 확률 조정해주기
                Debug.Log("Success");
                GameManager.Instance.ShowDescription("Success");
                //소환 
                over = true;
            }
            else
            {
                failCount--;
                //실패 알림 해주기
                Debug.Log($"DNA : {rightDNA.anchoredPosition.x} , Line : {line.anchoredPosition}");
                Debug.Log("Fail " + failCount);
                Reset();
            }
        }
        if (failCount <= 0)
        {
            //완전 실패 패널 닫아버리기
            GameManager.Instance.ShowDescription("Fail");
            Debug.Log("Game Over");
            over = true;
        }
    }*/

    private void Reset()
    {
        leftDNA.anchoredPosition = originLeftDNA;
        rightDNA.anchoredPosition = originRightDNA;
    }
}
