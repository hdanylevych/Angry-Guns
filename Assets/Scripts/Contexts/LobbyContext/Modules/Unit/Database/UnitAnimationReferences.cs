using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitAnimationReferences", menuName = "Scriptable Data/UnitAnimationReferences")]
public class UnitAnimationReferences : ScriptableObject
{
    public UnitAnimationReference[] animationReferences;
}

[Serializable]
public class UnitAnimationReference {
    public int SkinId;
    public GameObject Model;
    public GameObject PhotonViewModel;
}