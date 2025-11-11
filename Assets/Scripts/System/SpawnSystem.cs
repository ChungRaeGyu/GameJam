using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    int normalRate = FigureDataManager.normalSpawnRate;
    public int rareRate = FigureDataManager.rareSpawnRate;
    public GameObject effectPrefab;

    public List<GameObject> units = new List<GameObject>();
    public List<GameObject> RareUnits = new List<GameObject>();
    public void Spawn()
    {
        if (GameManager.Instance.spawnCount == FigureDataManager.upgraderareSpawnRate[0]
            || GameManager.Instance.spawnCount == FigureDataManager.upgraderareSpawnRate[1])
        {
            rareRate += FigureDataManager.plusRareRate;
        }
        int rand = Random.Range(0, 100);

        UnitSO[] tempSO = KeyToArray();

        if (rand < rareRate)
        {
            //희귀
            UnitSO unitSO = FindRareUnit(tempSO[0], tempSO[1]);
            GameObject temp = SpawnUnit(unitSO);
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
            RareUnits.Add(temp); //현재 필드위에 있는 레어 유닛
            DataManager.Instance.currentRareUnitSO.Add(unitSO); //도감에 넣어 놓기 위해
            GameManager.Instance.GameOver(RareUnits.Count);
        }
        else if (rand < rareRate + normalRate)
        {
            int random = Random.Range(0, 2);
            UnitSO unitSO = tempSO[random];
            SpawnUnit(unitSO);
        }
    }

    private GameObject SpawnUnit(UnitSO unitSO)
    {
        GameObject temp = Instantiate(unitSO.prefab, transform.position, Quaternion.identity);
        Unit tempUnit = temp.GetComponent<Unit>();
        tempUnit.unitSO = unitSO;
        tempUnit.Init();
        units.Add(temp); //현재 필드 위에 있는 유닛
        return temp;
    }

    private UnitSO[] KeyToArray()
    {
        List<UnitSO> tem = new List<UnitSO>();
        foreach (var t in GameManager.Instance.manipulationDNA)
        {
            tem.Add(t.Value);
        }

        return tem.ToArray();
    }

    private RareUnitSO FindRareUnit(UnitSO a, UnitSO b)
    {
        if (a == null || b == null) return null;

        foreach (var rare in GameManager.Instance.rareUnitsSO)
        {
            if (rare == null) continue;

            // 순서 무시 비교
            bool match = (rare.unitA == a && rare.unitB == b)
                      || (rare.unitA == b && rare.unitB == a);

            if (match)
                return rare;
        }

        return null; // 없으면 null 반환
    }
}
