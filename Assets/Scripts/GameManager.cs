using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public SpawnSystem spawnSystem;
    public EnergySystem energySystem;
    [SerializeField] private GameObject DNAManipulationPanel;

    public UnitSO[] normalUnitsSO;
    public RareUnitSO[] rareUnitsSO;

    public GameObject currentDNASlot;

    public Dictionary<GameObject,UnitSO> manipulationDNA = new Dictionary<GameObject, UnitSO>();

    [SerializeField] GameObject choiceDNAScrollView;
    [SerializeField] GameObject spaceBarPanel;


    [SerializeField] GameObject testDescriptionPanel;
    [SerializeField] TMP_Text testText;

    [SerializeField] Sprite uiSprite; //버튼의 기본 이미지

    public bool isPlaying = false;

    public int spawnCount = 0;

    public float EventTimer = 2f;
    
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
        isPlaying  = !DNAManipulationPanel.activeSelf;
    }

    public void SpaceBarPanelControl()
    {
        if (manipulationDNA.Count == 2)
        {
            if (energySystem.UseEnergy())
            {
                spaceBarPanel.SetActive(!spaceBarPanel.activeSelf);
                foreach (var t in manipulationDNA)
                {
                    t.Key.GetComponent<Image>().sprite = uiSprite;
                }
            }
            else
            {
                ShowDescription("a lack of energy");
            }
        }
        else
        {
            ShowDescription("Choose DNA");
        }

    }

    public void ShowDescription(string text)
    {
        Debug.Log("텍스트 : " + text);
        testDescriptionPanel.SetActive(true);
        testText.text = text;
        StartCoroutine(show());
    }
    IEnumerator show()
    {
        yield return new WaitForSecondsRealtime(1f);
        testDescriptionPanel.SetActive(false);
    }
    private void Start()
    {

    }
}
