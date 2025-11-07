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
        if (rand < fightEventRate)
        {
            if (GameManager.Instance.spawnSystem.units.Count <= 1)
                return;
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
                return;
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
        temp.transform.position = new Vector2(transform.position.x, transform.position.y + 3);
        temp.GetComponent<EventParent>().target1 = this.gameObject;
    }

    private void TogetherEvent(int type)
    {
        int num;
        GameObject temp2;
        do
        {
            num = Random.Range(0, GameManager.Instance.spawnSystem.units.Count);
            temp2 = GameManager.Instance.spawnSystem.units[num];
        } while (temp2 == this.gameObject);

        while (Vector2.Distance(transform.position,temp2.transform.position)<50)
        {
            gameObject.transform.position = Vector2.MoveTowards(transform.position, temp2.transform.position, speed * Time.deltaTime);
            temp2.transform.position = Vector2.MoveTowards(temp2.transform.position, gameObject.transform.position, speed * Time.deltaTime);
        }

        GameObject temp = Instantiate(events[type]);
        EventParent eventParent = temp.GetComponent<EventParent>();

        eventParent.target1 = this.gameObject;
        eventParent.target2 = temp2;
        
        temp2.GetComponent<EventSystem>().isEvent = true;
        Vector2 vector2 = (transform.position + temp2.transform.position) / 2;
        temp.transform.position = vector2;
    }

    public void EventOver()
    {
        isEvent = false;
    }
}
