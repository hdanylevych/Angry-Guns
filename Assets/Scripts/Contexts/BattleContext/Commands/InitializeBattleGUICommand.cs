using strange.extensions.command.impl;
using UnityEngine;

public class InitializeBattleGUICommand : Command
{
    public override void Execute()
    {
        GameManager.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));
        Debug.Log("Battle Initialized");
    }
}
