using System;
using UnityEngine;

public class UnitModel
{
    public int UnitId { get; private set; }
    public int SkinId { get; set; }
    public int Health { get; set; }
    public string UserId { get; set; }
    public string Nickname { get; set; }
    public Vector3 CurrentPosition { get; set; }
    public Vector3 Size { get; set; }

    public SerializableUnitModel SerializableModel
    {
        get =>  new SerializableUnitModel
                {
                    UnitId = UnitId,
                    SkinId = SkinId,
                    UserId = UserId,
                    Nickname = Nickname,
                    CurrentPosition = CurrentPosition,
                    Size = Size,
                    Health = Health
                };

        set
        {
            UnitId = value.UnitId;
            SkinId = value.SkinId;
            UserId = value.UserId;
            Nickname = value.Nickname;
            CurrentPosition = value.CurrentPosition;
            Size = value.Size;
            Health = value.Health;
        }
    }

    public UnitModel()
    {
    }

    public UnitModel(Vector3 position, Vector3 size, int unitId)
    {
        UnitId = unitId;
        CurrentPosition = position;
        Size = size;
    }
}
