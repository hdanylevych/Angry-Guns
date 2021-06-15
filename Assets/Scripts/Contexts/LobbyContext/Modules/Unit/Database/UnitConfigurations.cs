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
    public static UnitConfiguration Null
    {
        get
        {
            return new UnitConfiguration
                       {
                           Id = 0,
                           SkinId = 0,
                           HP = 0
                       };
        }
    }

    public int Id;
    public int SkinId;
    public int HP;
}
