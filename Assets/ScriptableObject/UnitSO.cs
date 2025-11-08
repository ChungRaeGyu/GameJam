using UnityEngine;
public enum kind
{
    aggressive,
    curious,
    cowardly,
    friendly,
    cynical,
    Count
}
[CreateAssetMenu(fileName = "UnitSO", menuName = "Scriptable Objects/UnitSO")]
public class UnitSO : ScriptableObject
{
    public Sprite sprite;
    [HideInInspector]
    public kind unitKind;
}
