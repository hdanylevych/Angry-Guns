using UnityEngine;

public interface IUnitModel
{
    int Id { get; }
    int SkinId { get; }
    Vector3 CurrentPosition { get; }
    Vector3 Size { get; }
}
