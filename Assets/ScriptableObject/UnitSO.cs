using UnityEngine;
public enum kind
{
    aggressive,
    curious,
    cowardly,
    friendly,
    cynical
}
[CreateAssetMenu(fileName = "UnitSO", menuName = "Scriptable Objects/UnitSO")]
public class UnitSO : ScriptableObject
{
    public Sprite sprite;
    public kind unitKind;
}
