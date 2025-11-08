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
    public UnitSO[] normalUnitsSO;
    [HideInInspector]
    public RareUnitSO[] rareUnitsSO;
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
    [SerializeField] GameObject choiceDNAScrollView;
    
    [SerializeField] GameObject spaceBarPanel;

    [Header("EventSystem")]
    public GameObject eventSystem;

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
        PlayingControl(!DNAManipulationPanel.activeSelf);
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
    public void GameOver(int num)
    {
        if (num >= goal) 
        {
            PlayingControl(false);
            StartCoroutine(GameIsOver());
            
        }
    }

    IEnumerator GameIsOver()
    {
        ShowDescription("You Win!");
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        SceneManager.LoadScene("CutScene");
    }
}
