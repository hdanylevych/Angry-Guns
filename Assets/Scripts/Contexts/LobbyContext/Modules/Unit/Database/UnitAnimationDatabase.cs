using UnityEngine;

public class UnitAnimationDatabase : IUnitAnimationDatabase
{
    private const string UnitAnimationReferencesLocation = "Databases/UnitAnimationReferences";
    
    private UnitAnimationReferences _animationReferences;

    [Inject] public IUnitDatabase UnitDatabase { get; set; }

    [PostConstruct]
    private void Initialize()
    {
        _animationReferences = Resources.Load<UnitAnimationReferences>(UnitAnimationReferencesLocation);
    }

    public UnitAnimationReference GetById(int id)
    {
        int skinId = UnitDatabase.Get(id).SkinId;

        return GetBySkinId(skinId);
    }

    public UnitAnimationReference GetBySkinId(int skinId)
    {
        foreach (var animationReference in _animationReferences.animationReferences)
        {
            if (animationReference.SkinId == skinId)
            {
                return animationReference;
            }
        }

        return null;
    }
}
