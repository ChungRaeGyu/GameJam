using UnityEngine;
interface ITargetable
{
    void SetTarget(GameObject[] objs, GameObject obj);
}
public class SpaceBarParent : MonoBehaviour,ITargetable
{
    [SerializeField] protected RectTransform leftDNA;
    [SerializeField] protected RectTransform rightDNA;
    [SerializeField] protected RectTransform line;

    [SerializeField] protected Vector2 originLeftDNA;
    [SerializeField] protected Vector2 originRightDNA;
    [SerializeField] protected float speed;

    protected bool over;
    [SerializeField] protected float failCount;

    protected GameObject[] targetObjs;
    protected GameObject eventIcon;
    public void SetTarget(GameObject[] objs,GameObject obj)
    {
        targetObjs = objs;
        eventIcon = obj;
    }
    private void Awake()
    {
        originLeftDNA = leftDNA.anchoredPosition;
        originRightDNA = rightDNA.anchoredPosition;
    }
    protected virtual void OnEnable()
    {
        Debug.Log("ONEnable");
        Reset();
        over = true;
        failCount = 3;
    }
    protected void Reset()
    {
        leftDNA.anchoredPosition = originLeftDNA;
        rightDNA.anchoredPosition = originRightDNA;
    }

    protected void Over()
    {
        foreach(GameObject obj in targetObjs)
        {
            if (obj != null)
            {
                obj.GetComponent<EventSystem>().EventOver();
            }
        }
        GameManager.Instance.PlayingControl(true);
        Destroy(eventIcon);
        Destroy(gameObject);
    }
}
