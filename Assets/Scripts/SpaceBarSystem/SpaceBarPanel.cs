using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceBarPanel : SpaceBarParent
{
    public GameObject O;
    public GameObject X;
    public Transform parent;
    public List<GameObject> objs = new List<GameObject>();
    protected override void OnEnable()
    {
        base.OnEnable();
        speed = 200;
        StartSetting();
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
                    UIManager.Instance.ShowEffectUI();
                    speed += 100;
                    objs.Add(Instantiate(O, parent));
                    Reset();
                    //이펙트 강화 성공 실패 이펙트 넣어주기
                }
                else
                {
                    failCount--;
                    objs.Add(Instantiate(X, parent));
                    Reset();
                }
            }
            else if (rightDNA.anchoredPosition.x < line.anchoredPosition.x - 10)
            {
                failCount--;
                objs.Add(Instantiate(X, parent));
                Reset();
                yield return null;
            }

            if (successCount >= 3)
            {
                over = false;
                //끝났을때를 확인하네 그냥 일단 다 꺼버리고 시작할때 원복 하면 되지 않을까
                GameManager.Instance.ShowDescription("Success");
                GameManager.Instance.StartC(GameManager.Instance.spawnSystem.CSpawn());
                gameObject.SetActive(false);
                GameManager.Instance.DNAManipulationPanelClose(true);
                //소환 

                yield break;
            }
            if (failCount <= 0)
            {
                //완전 실패 패널 닫아버리기
                over = false;
                GameManager.Instance.ShowDescription("Fail");
                gameObject.SetActive(false);
                GameManager.Instance.DNAManipulationPanelClose();
                yield break;
            }
        }
    }
    private void StartSetting()
    {
        ////ManipulationDNA패널이 열릴때 실행되어야겠네 게임매너지에 또 있다
        //foreach (var t in GameManager.Instance.manipulationDNA)
        //{
        //    t.Key.GetComponent<Button>().enabled = true;
        //    Image image = t.Key.GetComponent<RNAChange>().unitImage;
        //    image.sprite = GameManager.Instance.uiSprite;
        //    image.color = new Color(1, 1, 1, 0);
        //}
        //GameManager.Instance.manipulationDNA.Clear();
        foreach(var obj in objs)
        {
            Destroy(obj);
        }
    }
}
