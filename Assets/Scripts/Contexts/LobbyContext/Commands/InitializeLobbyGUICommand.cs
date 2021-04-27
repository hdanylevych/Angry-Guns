using strange.extensions.command.impl;
using strange.extensions.context.api;

using UnityEngine;

public class InitializeLobbyGUICommand : Command
{
    [Inject] public ISceneTransitionController SceneTransitionController { get; set; }
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextRoot { get; set; }
    [Inject] public ILobbyController LobbyController { get; set; }

    public override void Execute()
    {
        LobbyController.Initialize();
        LobbyController.Model.PlayerNickname = "Fearless";

        var lobbyPrefab = Resources.Load<GameObject>("GUI/LobbyCanvasMV");

        GameObject.Instantiate(lobbyPrefab, ContextRoot.transform);
    }
}
