using UnityEngine;
using UnityEngine.UI;

public class UnitCard : MonoBehaviour
{
    public UnitSO unitso;
    Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void Start()
    {
        GetComponent<Image>().sprite = unitso.sprite;
        button.onClick.AddListener(ChoiceDNA);
    }

    private void ChoiceDNA()
    {
        GameManager.Instance.currentDNASlot.GetComponent<Image>().sprite = unitso.sprite;
        GameManager.Instance.ChoiceDNAScrollViewControl();
        //여기서 확률 올려주기
    }

    

}
