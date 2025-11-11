using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

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
    
    public UnitSO[] stage1NormalSO;
    public UnitSO[] stage2NormalSO;

    public List<UnitSO[]> normalSOs = new List<UnitSO[]>();

    public RareUnitSO[] stage1RareUnitSO;
    public RareUnitSO[] stage2RareUnitSO;

    public List<UnitSO> currentRareUnitSO;

    public int stage = 1;

    public UnitSO[] GetSO()
    {
        if (stage == 1)
        {
            return stage1NormalSO;
        }
        else
        {
            return stage1NormalSO.Concat(stage2NormalSO).ToArray();
        }
    }
    public RareUnitSO[] GetRareSO()
    {
        if (stage == 1)
        {
            return stage1RareUnitSO;
        }
        else
        {
            return stage1RareUnitSO.Concat(stage2RareUnitSO).ToArray();
        }
    }

    public int GetGoal()
    {
        return stage == 1 ? 3 : 5;
    }
}
