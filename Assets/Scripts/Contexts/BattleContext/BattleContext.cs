using strange.extensions.context.impl;
using UnityEngine;

public class BattleContext : MVCSContext
{
    public BattleContext(MonoBehaviour contextView, bool autoStartup)
        : base(contextView, autoStartup)
    {
    }

    protected override void mapBindings()
    {
        injectionBinder.Bind<IUnitController>()
            .To<UnitController>()
            .ToSingleton();

        commandBinder.Bind<ContextStartSignal>()
            .To<InitializeUnitsCommand>()
            .To<InitializeBattleGUICommand>()
            .InSequence()
            .Once();
    }
}
