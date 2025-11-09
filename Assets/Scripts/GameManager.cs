using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int goal;

    [HideInInspector]
    public UnitSO[] normalUnitsSO = new UnitSO[0];
    [HideInInspector]
    public RareUnitSO[] rareUnitsSO = new RareUnitSO[0];

    public GameObject[] button;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Screen.SetResolution(640, 860,false);

    }
    private void Start()
    {
        normalUnitsSO = DataManager.Instance.GetSO();
        rareUnitsSO = DataManager.Instance.GetRareSO();
        goal = DataManager.Instance.GetGoal();
    }
    public SpawnSystem spawnSystem;
    public EnergySystem energySystem;



    [Header("DNA")]
    public GameObject currentDNASlot;
    public Dictionary<GameObject,UnitSO> manipulationDNA = new Dictionary<GameObject, UnitSO>();
    [SerializeField] private GameObject DNAManipulationPanel;
    [SerializeField] private GameObject DNAManipulationBackGround;

    [SerializeField] GameObject choiceDNAScrollView;
    
    [SerializeField] GameObject spaceBarPanel;

    [Header("EventSystem")]
    public GameObject eventSystem;

    [SerializeField] GameObject testDescriptionPanel;
    [SerializeField] Text testText;

    public Sprite uiSprite; //버튼의 기본 이미지

    public bool isPlaying = false;

    public int spawnCount = 0;

    public float EventTimer = 2f;

    public GameObject winPanel;

    public GameObject bookPanel;

    public Text goalText;

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
    public void ChoiceDNAClose()
    {
        choiceDNAScrollView.SetActive(false);
    }
    public void SpaceBarSystemClose()
    {
        spaceBarPanel.SetActive(false);
    }
    public void DNAManipulationPanelClose()
    {
        //DNA 조작 패널 닫기
        foreach (var t in manipulationDNA)
        {
            Debug.Log(t.Key.name + " t이름");
            t.Key.GetComponent<Button>().enabled = true;
            Image image = t.Key.GetComponent<RNAChange>().unitImage;
            image.sprite = uiSprite;
            image.color = new Color(1, 1, 1, 0);
        }
        manipulationDNA.Clear();
        DNAManipulationPanel.SetActive(false);
        DNAManipulationBackGround.SetActive(false);
    }
    public void DNAManipulationPanelControl()
    {
        StartCoroutine(PressButton());
    }
    IEnumerator PressButton()
    {
        button[0].SetActive(false);
        button[1].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        button[1].SetActive(false);
        button[0].SetActive(true);
        if (DNAManipulationBackGround.activeSelf)
        {
            SpaceBarPanelControl();
            yield break;
        }
        DNAManipulationPanel.SetActive(true);
        DNAManipulationBackGround.SetActive(true);
        PlayingControl(false);
    }
    public void PlayingControl(bool bol)
    {
        isPlaying = bol;

    }
    public void SpaceBarPanelControl()
    {
        if (manipulationDNA.Count == 2)
        {
            if (energySystem.UseEnergy())
            {
                spaceBarPanel.SetActive(!spaceBarPanel.activeSelf);
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
    }

    public void CheckDescription()
    {
        testDescriptionPanel.SetActive(false);

    }
    public void GameOver(int num)
    {
        goalText.text = $"{num}/{goal}";
        if (num >= goal) 
        {
            PlayingControl(false);
            winPanel.SetActive(true);
        }
    }

    public void BookControl()
    {
        bookPanel.SetActive(!bookPanel.activeSelf);
    }
}
