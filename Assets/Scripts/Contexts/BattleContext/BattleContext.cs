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
        commandBinder.Bind<ContextStartSignal>()
            .To<InitializeBattleGUICommand>();
    }
}
