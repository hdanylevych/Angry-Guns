using System;

using strange.extensions.mediation.impl;
using UnityEngine;

public class BattleHUD : View
{
    private static BattleHUD instance;

    [SerializeField] private VariableJoystick leftJoystick;
    [SerializeField] private VariableJoystick rightJoystick;

    public static BattleHUD Instance => instance;

    public static event Action OnUpdate;
    public VariableJoystick LeftJoystick => leftJoystick;
    public VariableJoystick RightJoystick => rightJoystick;


    [PostConstruct]
    private void Initialize()
    {
        instance = this;
    }

    private void Update()
    {
        OnUpdate?.Invoke();
    }
}
