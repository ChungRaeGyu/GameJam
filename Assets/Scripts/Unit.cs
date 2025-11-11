using UnityEngine;

public class Unit : MonoBehaviour
{
    //[HideInInspector]
    public UnitSO unitSO;
    
    [SerializeField] private float speed = 5f;
    [SerializeField] private float limittime = 5f;
    private float timer;
    private Vector2 moveDirection;

    private EventSystem eventSystem;
    void Awake()
    {
        eventSystem = GetComponent<EventSystem>();
    }
    private void Start()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.isPlaying &&!eventSystem.isEvent)
        {
            transform.Translate(moveDirection * speed * Time.fixedDeltaTime);
        }
    }
    void Update()
    {
        if (GameManager.Instance.isPlaying && !eventSystem.isEvent)
        {
            timer += Time.deltaTime;
            if(timer> limittime)
            {
                moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                timer = 0;
                limittime = Random.Range(1, 5);
                if (limittime == 4)
                {
                    moveDirection = Vector2.zero;   
                }
            }
        }
    }
    public void Init()
    {
        //여기서 성격을 정해주자
        unitSO.unitKind = (kind)Random.Range(0, (int)kind.Count);
        //성격에 따른 EventRate 조정
        eventSystem.SetRate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 normal = collision.contacts[0].normal;
            moveDirection = Vector2.Reflect(moveDirection, normal).normalized;
        }
    }
}
