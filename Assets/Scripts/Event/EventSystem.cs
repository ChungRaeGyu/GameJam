using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventType
{
    Fight,
    Pain,
    Love,
    Lonley
}
public class EventSystem : MonoBehaviour
{
    //싸움, 아픔, 사랑, 외로움
    float timer;
    [SerializeField]
    float limittime = 7f;

    [SerializeField] int fightEventRate = 25;
    [SerializeField] int painEventRate = 25;
    [SerializeField] int loveEventRate = 25;

    public bool isEvent = false; //event끝나면 false 만들어주기

    Unit unit;
    [SerializeField] GameObject[] events; //type에 맞게 넣어주기
    [SerializeField] float speed = 5f;
    private void Awake()
    {
        unit = GetComponent<Unit>();
    }
    private void Update()
    {
        if (!GameManager.Instance.isPlaying)return;
        if (timer < limittime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            limittime = Random.Range(7f, 10f);
            EventTrigger();
        }
    }
    private void EventTrigger()
    {
        int rand = Random.Range(0, 100);
        isEvent = true;
        Debug.Log("멈춤");
        if (rand < fightEventRate)
        {
            if (GameManager.Instance.spawnSystem.units.Count <= 1)
            {
                isEvent = false;
                return;
            }
            //fight //달라붙기
            TogetherEvent((int)EventType.Fight);
        }
        else if (rand < fightEventRate + painEventRate)
        {
            //pain //혼자
            AloneEvent((int)EventType.Pain);
        }
        else if (rand < fightEventRate + painEventRate + loveEventRate)
        {
            if (GameManager.Instance.spawnSystem.units.Count <= 1)
            {
                isEvent = false;
                return;
            }
            //love //달라붙기
            TogetherEvent((int)EventType.Love);

        }
        else
        {
            AloneEvent((int)EventType.Lonley);
            //lonley //혼자
        }
    }

    private void AloneEvent(int type)
    {
        GameObject temp = Instantiate(events[type]);
        temp.transform.position = new Vector2(transform.position.x, transform.position.y +1);
        temp.GetComponent<EventParent>().target1 = this.gameObject;
    }

    private void TogetherEvent(int type)
    {
        GameObject temp2;
        List<GameObject> availableUnits = new List<GameObject>();
        foreach (var t in GameManager.Instance.spawnSystem.units)
        {
            if (t != this.gameObject && t.GetComponent<EventSystem>().isEvent == false)
            {
                availableUnits.Add(t);
            }
        }
        if (availableUnits.Count == 0)
        {
            EventOver();
            return;
        }
        temp2 = availableUnits[Random.Range(0, availableUnits.Count)];

        StartCoroutine(MoveTogether(temp2, type));

    }
    IEnumerator MoveTogether(GameObject temp2, int type)
    {
        while (Vector2.Distance(transform.position, temp2.transform.position) > 1.5f)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, temp2.transform.position, speed * Time.deltaTime);
            temp2.transform.position = Vector2.MoveTowards(temp2.transform.position, gameObject.transform.position, speed * Time.deltaTime);
            yield return null;
        }
        Debug.Log(Vector2.Distance(transform.position, temp2.transform.position));
        GameObject temp = Instantiate(events[type]);
        EventParent eventParent = temp.GetComponent<EventParent>();

        eventParent.target1 = this.gameObject;
        eventParent.target2 = temp2;

        var eventSystem = temp2.GetComponent<EventSystem>();
        eventSystem.isEvent = true;
        eventSystem.timer = 0;

        Vector2 vector2 = (transform.position + temp2.transform.position) / 2;
        temp.transform.position = vector2;
        //타이머는 SpriteClickHandler에서 멈추고 재개

    }
    public void EventOver()
    {
        //Event에서 마지막에 이거 호출
        isEvent = false;
    }
}
