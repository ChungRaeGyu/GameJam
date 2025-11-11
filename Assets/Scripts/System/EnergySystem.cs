using System;
using UnityEngine;
using UnityEngine.UI;

public class EnergySystem : MonoBehaviour
{
    [SerializeField] int maxEnergy = 4;
    [SerializeField] int currentEnergy;
    [SerializeField] GameObject[] energys;

    private void Start()
    {
        currentEnergy = maxEnergy;
    }

    public bool UseEnergy()
    {
        if (currentEnergy > 0)
        {
            currentEnergy--;
            energys[currentEnergy].SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RecoverEnergy()
    {
        currentEnergy = Math.Min(currentEnergy + 2, maxEnergy);
        for (int i=0; i < currentEnergy; i++)
        {
            energys[i].SetActive(false);
        }
    }

    
}
