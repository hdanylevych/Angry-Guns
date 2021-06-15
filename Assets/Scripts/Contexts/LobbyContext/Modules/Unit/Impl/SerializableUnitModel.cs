using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SerializableUnitModel
{
    public int UnitId;
    public int SkinId;
    public int HP;
    public string UserId;
    public string Nickname;
    public Vector3 CurrentPosition;
    public Vector3 Size;
}
