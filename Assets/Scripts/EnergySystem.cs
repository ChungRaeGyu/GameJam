using System;
using UnityEngine;
using UnityEngine.UI;

public class EnergySystem : MonoBehaviour
{
    [SerializeField] GameObject energyPrefab;
    [SerializeField] Transform energyParent;
    [SerializeField] Sprite[] energySprites;
    [SerializeField] int maxEnergy = 4;
    [SerializeField] int currentEnergy;
    [SerializeField] Image[] energys;

    private void Awake()
    {
        energys = new Image[maxEnergy];
    }
    private void Start()
    {
        currentEnergy = maxEnergy;
        for (int i=0; i<maxEnergy; i++)
        {
            energys[i] = Instantiate(energyPrefab, energyParent).GetComponent<Image>();
        }
    }

    public void UseEnergy()
    {
        if (currentEnergy > 0)
        {
            currentEnergy--;
            energys[currentEnergy].sprite = energySprites[1];
        }
    }

    public void RecoverEnergy()
    {
        currentEnergy = Math.Min(currentEnergy + 2, maxEnergy);
        for (int i=0; i < currentEnergy; i++)
        {
            energys[i].sprite = energySprites[0];
        }
    }

    
}
