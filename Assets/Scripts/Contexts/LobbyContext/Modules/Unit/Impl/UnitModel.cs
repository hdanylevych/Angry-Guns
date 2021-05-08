using UnityEngine;

public class UnitModel : IUnitModel
{
    public int Id { get; private set; }
    public int SkinId { get; private set; }
    public Vector3 CurrentPosition { get; set; }
    public Vector3 Size { get; set; }

    public UnitModel(Vector3 position, Vector3 size, int id)
    {
        Id = id;
        CurrentPosition = position;
        Size = size;
    }
}
