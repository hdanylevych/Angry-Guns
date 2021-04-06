using strange.extensions.context.api;

using UnityEngine;

public class UnitController : IUnitController
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextRoot { get; set; }

    public void Initialize()
    {
        var unitTestObject = new GameObject("TEST GAME OBJECT");
        unitTestObject.transform.parent = ContextRoot.transform;
    }

    public void Update(float deltaTime)
    {
    }
}
