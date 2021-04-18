using strange.extensions.context.api;

using UnityEngine;

public class UnitController : IUnitController
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextRoot { get; set; }

    public void Initialize()
    {
    }

    public void Update(float deltaTime)
    {
    }
}
