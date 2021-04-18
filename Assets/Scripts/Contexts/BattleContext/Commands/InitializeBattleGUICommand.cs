using strange.extensions.command.impl;
using UnityEngine;

public class InitializeBattleGUICommand : Command
{
    public override void Execute()
    {
        Debug.Log("Battle GUI Initialized");
    }
}
