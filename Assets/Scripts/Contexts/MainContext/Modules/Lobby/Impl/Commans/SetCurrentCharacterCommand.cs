using strange.extensions.command.impl;

public class SetCurrentCharacterCommand : Command
{
    public int UnitId { get; set; }

    [Inject] public ILobbyController LobbyController { get; set; }

    public override void Execute()
    {
        LobbyController.Model.CurrentUnitId = UnitId;
    }
}
