using UnityEngine;

public class Unit : MonoBehaviour
{
    //[HideInInspector]
    public UnitSO unitSO;
    private SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {

        }
    }
    public void Init()
    {
        spriteRenderer.sprite = unitSO.sprite;
        GameManager.Instance.isPlaying = true;
    }
}
