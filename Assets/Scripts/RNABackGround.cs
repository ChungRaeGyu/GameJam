using UnityEngine;
using UnityEngine.UI;

public class RNABackGround : MonoBehaviour
{
    public Text rateText;

    // Update is called once per frame
    void Update()
    {
        rateText.text = $"돌연변이 확률 \n{GameManager.Instance.spawnSystem.rareRate}%";
    }
}
