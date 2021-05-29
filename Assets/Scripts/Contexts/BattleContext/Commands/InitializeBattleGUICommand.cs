using strange.extensions.command.impl;

public class InitializeBattleGUICommand : Command
{
    private const string HeroCanvasPrefabLocation = "GUI/HeroMV";

    [Inject] public ILobbyStateProvider LobbyStateProvider { get; set; }
    [Inject] public IHeroMediator HeroMediator { get; set; }

    public override void Execute()
    {
    }
}
