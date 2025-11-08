using System.Collections;
using UnityEngine;

public class FightEventSystem : SpaceBarParent, ITargetable
{


    //줌인 효과
    //성공 실패시 줌아웃, 및 상황 원상 복구 
    // 성공 효과 
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(MouseClick());
    }

    IEnumerator MouseClick()
    {
        //줌인 줌인 효과 주기
        while (over)
        {
            yield return null;
            leftDNA.anchoredPosition += new Vector2(speed * Time.deltaTime, 0);
            rightDNA.anchoredPosition -= new Vector2(speed * Time.deltaTime, 0);

            if (Input.GetMouseButtonDown(0))
            {
                if (line.anchoredPosition.x - 5 <= rightDNA.anchoredPosition.x && rightDNA.anchoredPosition.x <= line.anchoredPosition.x + 60)
                {
                    over = false;
                    //성공 알림 해주고 패널 조금있다가 닫기
                    //여기서 확률 조정해주기
                    Debug.Log("Success");
                    GameManager.Instance.ShowDescription("Success");
                    //성공
                    GameManager.Instance.spawnSystem.rareRate += 5;
                    GameManager.Instance.energySystem.RecoverEnergy();

                    yield return new WaitForSecondsRealtime(1f);
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
                over = false;
            }
        }
        //이벤트 끝 
        Over();
    }
}
