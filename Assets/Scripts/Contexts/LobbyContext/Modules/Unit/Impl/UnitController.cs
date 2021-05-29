using System;
using strange.extensions.context.api;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : IUnitController
{
    private static UnitController _instance;

    private List<UnitModel> _models = new List<UnitModel>(6);

    public event Action<UnitModel> NewModelReceived;

    public static IUnitController Instance => _instance;

    public IReadOnlyList<UnitModel> Models => _models;

    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextRoot { get; set; }

    [PostConstruct]
    private void Construct()
    {
        _instance = this;
        Debug.Log("UNIT CONTROLLER INITIALIZED");
    }

    public void AddModel(UnitModel model)
    {
        _models.Add(model);

        NewModelReceived?.Invoke(model);
    }

    private void Update(float deltaTime)
    {
    }
}
