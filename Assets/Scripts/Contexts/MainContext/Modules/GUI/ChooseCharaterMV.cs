using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityWeld.Binding;

public class ChooseCharaterMV : CanvasMV
{
    [Inject] public CharacterChoosenSignal CharacterChoosenSignal { get; set; }

    [Binding]
    private void OnUnitClicked()
    {
        CharacterChoosenSignal.Dispatch(1);
    }
}
