using strange.extensions.command.impl;
using strange.extensions.context.api;

using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeUnitsCommand : Command
{
    private const string GameManagerPrefabLocation = "GameManager";
    
    [Inject] public IUnitController UnitController { get; set; }
    [Inject] public ILobbyController LobbyController { get; set; }
    [Inject] public IUnitAnimationDatabase UnitAnimationDatabase { get; set; }
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject Root { get; set; }

    public override void Execute()
    {
        var gameManagerPrefab = Resources.Load<GameObject>(GameManagerPrefabLocation);
        var gameManagerInstance = GameObject.Instantiate(gameManagerPrefab, Root.transform);

        var playerUnitPrefabName = UnitAnimationDatabase.GetById(LobbyController.Model.CurrentUnitId).PhotonViewModel.name;

        var playerInstance = gameManagerInstance.GetComponent<GameManager>().Initialize(playerUnitPrefabName);
        
        UnitController.Initialize();
    }
}
