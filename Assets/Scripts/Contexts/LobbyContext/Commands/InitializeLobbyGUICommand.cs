using strange.extensions.command.impl;
using strange.extensions.context.api;

using UnityEngine;
using UnityEngine.EventSystems;

public class InitializeLobbyGUICommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextRoot { get; set; }
    [Inject] public ILobbyController LobbyController { get; set; }

    public override void Execute()
    {
        LobbyController.Initialize();

        LobbyController.Model.PlayerLogin = "Fearless";

        var lobbyPrefab = Resources.Load<GameObject>("GUI/LobbyCanvasMV");

        GameObject.Instantiate(lobbyPrefab, ContextRoot.transform);
    }
}
