using System;
using UnityEngine;

public class UnitModel
{
    private UnitConfiguration _config;
    
    public int MaxHP => _config.HP;

    public int UnitId { get; private set; }
    public int SkinId { get; set; }
    public int HP { get; set; }
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
                    HP = HP
                };

        set
        {
            UnitId = value.UnitId;
            SkinId = value.SkinId;
            UserId = value.UserId;
            Nickname = value.Nickname;
            CurrentPosition = value.CurrentPosition;
            Size = value.Size;
            HP = value.HP;
        }
    }

    public UnitModel(Vector3 position, Vector3 size, UnitConfiguration config)
    {
        _config = config;

        UnitId = config.Id;
        CurrentPosition = position;
        Size = size;
        HP = MaxHP;
    }
}
