using System.Collections;
using UnityEngine;
using UnityEngine.UI;

enum UI
{
    NEW,
    ENERGY
}
public class UIManager : Singleton<UIManager>
{
    //지금 처럼 그냥 맵 중간에서 보여줄꺼면 worldposition으로 할 필요 없음 ㅇㅇ
    [SerializeField] GameObject[] prefab;

    public void ShowText(Vector2 pos,int ui)
    {
        //없어지는 텍스트
        StartCoroutine(CShowText(pos,ui));
    }
    IEnumerator CShowText(Vector2 pos,int ui)
    {
        //이렇게 하고 저 프리펩에 위로 올라가는 애니메이션 + 사라지기 
        yield return null;
        GameObject temp = Instantiate(prefab[ui], new Vector2(pos.x,pos.y+2), Quaternion.identity);
    }
}
