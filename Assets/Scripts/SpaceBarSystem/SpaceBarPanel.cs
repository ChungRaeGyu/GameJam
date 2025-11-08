using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpaceBarPanel : SpaceBarParent
{

    protected override void OnEnable()
    {
        base.OnEnable();
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
                if (line.anchoredPosition.x - 5 <= rightDNA.anchoredPosition.x && rightDNA.anchoredPosition.x <= line.anchoredPosition.x + 60)
                {
                    //성공 알림 해주고 패널 조금있다가 닫기
                    //여기서 확률 조정해주기
                    successCount++;
                    Debug.Log("Success" + successCount);
                    speed += 100;
                    Reset();
                    //이펙트 강화 성공 실패 이펙트 넣어주기 

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

            if (successCount >= 3)
            {
                over = false;

                GameManager.Instance.ShowDescription("Success");
                yield return new WaitForSecondsRealtime(1f);
                SoundManager.instance.SpawnSoundPlay();
                GameManager.Instance.spawnSystem.Spawn();
                //소환 
                yield return new WaitForSecondsRealtime(1f);
                StartCoroutine(End());
                gameObject.SetActive(false);
                GameManager.Instance.DNAManipulationPanelClose();
                speed = 200;

                yield break;
            }
            if (failCount <= 0)
            {
                //완전 실패 패널 닫아버리기
                GameManager.Instance.ShowDescription("Fail");
                Debug.Log("Game Over");
                yield return new WaitForSecondsRealtime(1f);
                StartCoroutine(End());
                gameObject.SetActive(false);
                GameManager.Instance.DNAManipulationPanelClose();
                over = false;
                speed = 200;
            }
        }
    }
    IEnumerator End()
    {
        yield return null;
        foreach (var t in GameManager.Instance.manipulationDNA)
        {
            GameObject temp = t.Key.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject; ;
            Image image = temp.GetComponentInChildren<Image>();
            image.sprite = GameManager.Instance.uiSprite;
            image.color = new Color(1, 1, 1, 0);
        }

        //다 원상복구 시키기 
        //AnimatorOver 실행
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
}
