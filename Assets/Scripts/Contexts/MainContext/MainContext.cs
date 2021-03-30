using strange.extensions.context.impl;
using UnityEngine;

public class MainContext : MVCSContext
{
    public MainContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) 
    {
    }

    protected override void mapBindings()
    {
        injectionBinder.Bind<CharacterChoosenSignal>()
            .To<CharacterChoosenSignal>();

        injectionBinder.Bind<IUnitDatabase>()
            .To<UnitDatabase>()
            .ToSingleton();

        injectionBinder.Bind<ILobbyController>()
            .To<LobbyController>()
            .ToSingleton();

        injectionBinder.Bind<IUnitController>()
            .To<UnitController>()
            .ToSingleton();

        commandBinder.Bind<ContextStartSignal>()
            .To<InitializeUnitsCommand>()
            .To<InitializeLobbyGUICommand>();
    }
}
