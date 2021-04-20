using Photon.Pun;
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

        if (playerUnitPrefabName == string.Empty)
        {
            Debug.LogError($"GameManager: couldn't locate player prefab by path: {playerUnitPrefabName} ");
        }
        else
        {
            if (PlayerManager.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);

                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                var playerInstance = PhotonNetwork.Instantiate("PhotonViewModels/" + playerUnitPrefabName, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
                playerInstance.transform.parent = Root.transform.parent;
            }
            else
            {
                Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
            }
        }
        
        UnitController.Initialize();
    }
}
