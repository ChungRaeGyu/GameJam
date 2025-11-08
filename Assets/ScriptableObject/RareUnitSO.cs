using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RareUnitSO", menuName = "Scriptable Objects/RareUnitSO")]

public class RareUnitSO : UnitSO
{
    public UnitSO unitA;
    public UnitSO unitB;
    public string name;
    public string description;
}
