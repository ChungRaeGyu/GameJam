
using UnityEngine;
using UnityEngine.UI;

public class RNAChange : MonoBehaviour
{

    [SerializeField] Sprite[] redTarget;
    [SerializeField] Sprite[] greenTarget;

    public Image[] target;
    public Image image;
    public Image unitImage;
    public RectTransform parent;
    public Vector2 origin;

    public Animator anim;
    private void Awake()
    {
        origin = parent.anchoredPosition;

    }
    private void OnEnable()
    {
        anim.enabled = false;
        Change(false);
        parent.anchoredPosition = origin;
        anim.enabled = true;
    }

    public void Change(bool bol)
    {
        if (bol)
        {
            for (int i = 0; i < redTarget.Length; i++)
            {
                target[i].sprite = greenTarget[i];
            }
            image.color = new Color(121/255f, 255 / 255f, 147 / 255f, 120 / 255f);
        }
        else
        {
            for (int i = 0; i < redTarget.Length; i++)
            {
                target[i].sprite = redTarget[i];
            }
            image.color = new Color(250 / 255f, 58 / 255f, 58 / 255f, 120 / 255f);

        }
    }
}
