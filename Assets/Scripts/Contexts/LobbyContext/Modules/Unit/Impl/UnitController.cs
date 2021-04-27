using strange.extensions.context.api;

using UnityEngine;

public class UnitController : IUnitController
{
    private UnitModel _playerModel;
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextRoot { get; set; }

    public void Initialize(UnitModel model)
    {
        _playerModel = model;
    }

    public void Update(float deltaTime)
    {
    }
}
