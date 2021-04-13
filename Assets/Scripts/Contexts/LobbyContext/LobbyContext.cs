using strange.extensions.context.impl;
using UnityEngine;

public class LobbyContext : MVCSContext
{
    public LobbyContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) 
    {
    }

    protected override void mapBindings()
    {
        injectionBinder.Bind<BattleSceneLoadedSignal>()
            .ToSingleton();

        injectionBinder.Bind<CharacterChoosenSignal>()
            .ToSingleton();

        injectionBinder.Bind<IUnitDatabase>()
            .To<UnitDatabase>() 
            .ToSingleton()
            .CrossContext();

        injectionBinder.Bind<ILobbyController>()
            .To<LobbyController>()
            .ToSingleton();

        injectionBinder.Bind<IUnitController>()
            .To<UnitController>()
            .ToSingleton();

        injectionBinder.Bind<ISceneTransitionController>()
            .To<SceneTransitionController>()
            .ToSingleton();

        commandBinder.Bind<ContextStartSignal>()
            .To<InitializeUnitsCommand>()
            .To<InitializeLobbyGUICommand>();
    }
}
