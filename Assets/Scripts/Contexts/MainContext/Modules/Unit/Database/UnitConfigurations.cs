using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfigurations", menuName = "Scriptable Data/UnitConfigurations")]
public class UnitConfigurations : ScriptableObject
{
    public UnitConfiguration[] unitConfigurations;
}

[Serializable]
public class UnitConfiguration
{
    public int Id;
    public int SkinId;
}
