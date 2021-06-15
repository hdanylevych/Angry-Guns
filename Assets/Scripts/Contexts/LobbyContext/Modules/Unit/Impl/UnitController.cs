using System;
using strange.extensions.context.api;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class UnitController : IUnitController
{
    private static UnitController _instance;

    private UnitModel _myModel;
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
        BattleHUD.OnUpdate += Update;
    }

    public void AddModel(UnitModel model, bool isMine = false)
    {
        if (isMine)
        {
            _myModel = model;
        }

        _models.Add(model);

        NewModelReceived?.Invoke(model);
    }

    private void Update()
    {
        if (Random.Range(0, 500) == 0)
        {
            Debug.Log("HP REDUCED");
            _myModel.HP -= 5;
        }
    }
}
