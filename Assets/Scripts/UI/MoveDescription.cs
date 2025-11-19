using UnityEngine;

public class MoveDescription : MonoBehaviour
{
    // Update is called once per frame
    RectTransform rectTransform;
    [SerializeField] float speed = 1f;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, speed);
    }
}
