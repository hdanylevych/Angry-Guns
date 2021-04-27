using UnityEngine;

public class UnitModel
{
    private int _id;
    private int _skinId;

    private Vector3 _currentPosition;
    private Vector3 _size;

    public int Id => _id;
    public int SkinId => _skinId;
    public Vector3 CurrentPosition => _currentPosition;
    public Vector3 Size => _size;

    public UnitModel(Vector3 position, Vector3 size, int id)
    {
        _id = id;
        _currentPosition = position;
        _size = size;
    }
}
