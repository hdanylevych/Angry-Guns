using strange.extensions.command.impl;

public class InitializeBattleGUICommand : Command
{
    private const string HeroCanvasPrefabLocation = "GUI/HeroMV";

    [Inject] public ILobbyStateProvider LobbyStateProvider { get; set; }
    [Inject] public IHeroMediator HeroMediator { get; set; }
    [Inject] public IUnitController UnitController { get; set; }

    public override void Execute()
    {
        //var heroCanvasPrefab = Resources.Load<GameObject>(HeroCanvasPrefabLocation);
        //var heroCanvasInstance = GameObject.Instantiate(heroCanvasPrefab, ContextView.transform);

       // var heroMV = heroCanvasInstance.GetComponent<HeroMV>();

       HeroMediator.Initialize(UnitController.Models);
    }
}
