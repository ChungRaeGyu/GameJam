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
        GameObject temp = GameManager.Instance.currentDNASlot.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject; ;
        Image image= temp.GetComponentInChildren<Image>();
        Debug.Log(image.gameObject.name);
        image.sprite = unitso.sprite;
        image.color = new Color(1,1,1,1);

        GameManager.Instance.currentDNASlot.GetComponent<RNAChange>().anim.SetTrigger("Start");
        GameManager.Instance.currentDNASlot.GetComponent<Button>().enabled = false;

        GameManager.Instance.currentDNASlot.GetComponent<RNAChange>().Change(true);

        if (GameManager.Instance.manipulationDNA.ContainsKey(GameManager.Instance.currentDNASlot))
        {
            GameManager.Instance.manipulationDNA[GameManager.Instance.currentDNASlot] = unitso;
        }
        else
        {
            GameManager.Instance.manipulationDNA.Add(GameManager.Instance.currentDNASlot, unitso);
        }
        GameManager.Instance.ChoiceDNAScrollViewControl();
        
    }

    

}
