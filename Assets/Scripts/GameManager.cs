using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    [SerializeField] private GameObject DNAManipulationPanel;

    public UnitSO[] units;
    public GameObject currentDNASlot;

    [SerializeField] GameObject choiceDNAScrollView;
    [SerializeField] GameObject spaceBarPanel;

    public void ChoiceDNAScrollViewControl(GameObject obj = null)
    {
        choiceDNAScrollView.SetActive(!choiceDNAScrollView.activeSelf);
        if (currentDNASlot == null)
        {
            currentDNASlot = obj;
        }
        else
        {
            currentDNASlot = null;
        }
    }

    public void DNAManipulationPanelControl()
    {
        DNAManipulationPanel.SetActive(!DNAManipulationPanel.activeSelf);
    }

    public void SpaceBarPanelControl()
    {
        spaceBarPanel.SetActive(!spaceBarPanel.activeSelf);
    }

}
