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
        if(GameManager.Instance.manipulationDNA.ContainsKey(GameManager.Instance.currentDNASlot))
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
