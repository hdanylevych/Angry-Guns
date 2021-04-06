using System.ComponentModel;
using System.Runtime.CompilerServices;

using strange.extensions.mediation.impl;

using UnityEngine;

public class CanvasMV : View, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

