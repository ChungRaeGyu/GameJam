using System.Collections;
using UnityEngine;

public class SpriteClickHandler : MonoBehaviour
{
    private Camera cam;
    private EventParent eventParent;
    private Coroutine c;
    private void Awake()
    {
        eventParent = GetComponent<EventParent>();
    }
    private void Start()
    {
        cam = Camera.main;
        c = StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(2f);
        eventParent.target1.GetComponent<EventSystem>().EventOver();
        eventParent.target2.GetComponent<EventSystem>().EventOver();

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick(Input.mousePosition);
        }

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            CheckClick(Input.touches[0].position);
        }
    }

    private void CheckClick(Vector2 screenPos)
    {
        Vector2 worldPos = cam.ScreenToWorldPoint(screenPos);
        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            // 클릭된 오브젝트가 자신일 때
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log($"{gameObject.name} 클릭됨!");
                OnClick();
            }
        }
    }

    private void OnClick()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        StopCoroutine(c);//코루틴 멈췄고 
        //각종 이벤트를 실행하는 코드작성 줌을 하던가 패널을 열던가
        //아마 줌 하고 패널도 열어야 할꺼같은데 ㅋㅋ
        //그렇다 치고 
    }
}
