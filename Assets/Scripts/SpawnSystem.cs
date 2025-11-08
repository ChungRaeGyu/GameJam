using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    int normalRate = 90;
    public int rareRate = 10;

    [SerializeField] GameObject unitPrefab;

    public List<GameObject> units = new List<GameObject>();
    public void Spawn()
    {
        if (GameManager.Instance.spawnCount == 5 || GameManager.Instance.spawnCount == 9)
        {
            rareRate += 10;
        }
        int rand = Random.Range(0, 100);
        if (rand < rareRate)
        {
            //Èñ±Í
            GameObject temp = Instantiate(unitPrefab, transform.position, Quaternion.identity);
            UnitSO[] tempSO = KeyToArray();
            Unit tempUnit = temp.GetComponent<Unit>();
            tempUnit.unitSO = FindRareUnit(tempSO[0], tempSO[1]);
            tempUnit.Init();
            units.Add(temp);
        }
        else if (rand < rareRate+normalRate)
        {
            //Èñ±Í°¡ ¾Æ´Ò È®·ü
            GameObject temp = Instantiate(unitPrefab, transform.position, Quaternion.identity);
            int random = Random.Range(0, 2);
            UnitSO[] tempSO = KeyToArray();

            Unit tempUnit = temp.GetComponent<Unit>();
            tempUnit.unitSO = tempSO[random];
            tempUnit.Init();
            units.Add(temp);
        }
/*        else
        {
            GameManager.Instance.ShowDescription("SpawnFail");
            //½ÇÆÐÈ®·ü ³ª¸ÓÁö 
        }*/
        GameManager.Instance.manipulationDNA.Clear();
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

            // ¼ø¼­ ¹«½Ã ºñ±³
            bool match = (rare.unitA == a && rare.unitB == b)
                      || (rare.unitA == b && rare.unitB == a);

            if (match)
                return rare;
        }

        return null; // ¾øÀ¸¸é null ¹ÝÈ¯
    }
}
