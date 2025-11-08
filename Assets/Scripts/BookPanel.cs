using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BookPanel : MonoBehaviour
{
    [SerializeField] Text nameTxt;
    [SerializeField] Text descriptionTxt;
    [SerializeField] Image image;
    public int num = 0;
    private void OnEnable()
    {
        if (DataManager.Instance.currentRareUnitSO.Count != 0)
        {
            UnitSO unitSO = DataManager.Instance.currentRareUnitSO[0];
            Set(unitSO);
        }
    }
    public void Set(UnitSO unitSO)
    {
        nameTxt.text = $"#{(num+2).ToString("D3")}{unitSO.nametxt}";
        descriptionTxt.text = unitSO.description;
        image.sprite = unitSO.sprite;
    }
    //애니메이션 중간에 넣어주기 애니메이션 이벤트
    public void Prev()
    {
        if (num > 0)
        {
            num--;
            Set(DataManager.Instance.currentRareUnitSO[num]);
        }
       
    }
    public void Next()
    {
        
        if(num< DataManager.Instance.currentRareUnitSO.Count-1)
        {
            num++;
            Set(DataManager.Instance.currentRareUnitSO[num]);
        }
        

    }
}
