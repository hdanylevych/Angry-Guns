using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementController : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private VariableJoystick _joystick;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("VelocityX", _joystick.Horizontal);
        _animator.SetFloat("VelocityZ", _joystick.Vertical);
    }
}
