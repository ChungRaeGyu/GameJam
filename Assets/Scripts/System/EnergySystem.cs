using System;
using UnityEngine;
using UnityEngine.UI;

public class EnergySystem : MonoBehaviour
{
    [SerializeField] int maxEnergy = 4;
    [SerializeField] int currentEnergy;
    [SerializeField] Image[] energys;

    private void Start()
    {
        currentEnergy = maxEnergy;
    }

    public bool UseEnergy()
    {
        if (currentEnergy > 0)
        {
            currentEnergy--;
            energys[currentEnergy].color = new Color(1,1,1,1);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RecoverEnergy(Transform target)
    {
        currentEnergy = Math.Min(currentEnergy + 2, maxEnergy);
        for (int i=0; i < currentEnergy; i++)
        {
            energys[i].color = new Color(1, 1, 1, 0);
        }
        UIManager.Instance.ShowText(target, (int)UI.ENERGY);
    }

    
}
