using strange.extensions.context.impl;

using UnityEngine;

public class BattleRoot : ContextView
{
    private void Awake()
    {
        Debug.Log("Battle Context Awake called");

        var context = new BattleContext(this, true);
        context.Start();
    }
}
