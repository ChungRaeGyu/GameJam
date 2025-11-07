using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    //[HideInInspector]
    public UnitSO unitSO;
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] private float speed = 5f;
    [SerializeField] private float limittime = 5f;
    private float timer;
    private Vector2 moveDirection;
    private int rand;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.isPlaying)
        {
            transform.Translate(moveDirection * speed * Time.fixedDeltaTime);
        }
    }
    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            timer += Time.deltaTime;
            if(timer> limittime)
            {
                moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                timer = 0;
                limittime = Random.Range(1, 4);
            }
        }
    }
    public void Init()
    {
        spriteRenderer.sprite = unitSO.sprite;
        GameManager.Instance.isPlaying = true;
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
