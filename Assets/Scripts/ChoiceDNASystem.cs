using UnityEngine;
using UnityEngine.UI;

public class ChoiceDNASystem : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject cardPrefab;

    private void Start()
    {
        for(int i=0; i < GameManager.Instance.units.Length; i++)
        {
            GameObject temp = Instantiate(cardPrefab, content);
            temp.GetComponent<UnitCard>().unitso = GameManager.Instance.units[i];

        }
    }
}
