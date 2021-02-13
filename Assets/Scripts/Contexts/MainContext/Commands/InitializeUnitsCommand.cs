using strange.extensions.command.impl;

public class InitializeUnitsCommand : Command
{
    [Inject] public IUnitController UnitController { get; set; }

    public override void Execute()
    {
        UnitController.Initialize();
    }
}
