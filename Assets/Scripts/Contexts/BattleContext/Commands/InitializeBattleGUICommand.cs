using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;

using UnityEngine;

public class InitializeBattleGUICommand : Command
{
    private const string HeroCanvasPrefabLocation = "GUI/HeroMV";

    [Inject] public ILobbyStateProvider LobbyStateProvider { get; set; } 
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }

    public override void Execute()
    {
        var heroCanvasPrefab = Resources.Load<GameObject>(HeroCanvasPrefabLocation);
        var heroCanvasInstance = GameObject.Instantiate(heroCanvasPrefab, ContextView.transform);

        var heroMV = heroCanvasInstance.GetComponent<HeroMV>();

        heroMV.Nickname = LobbyStateProvider.Model.PlayerNickname;
    }
}
