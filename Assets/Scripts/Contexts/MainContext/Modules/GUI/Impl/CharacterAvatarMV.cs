using System;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class CharacterAvatarMV : CanvasMV
{
    private bool _isChosen;
    private int _id;
    private Sprite _avatar;

    [Binding]
    public Sprite Avatar
    {
        get => _avatar;

        set
        {
            if (_avatar == value)
                return;

            _avatar = value;

            OnPropertyChanged();
        }
    }

    [Binding]
    public bool IsChosen
    {
        get => _isChosen;

        set
        {
            if (_isChosen == value)
                return;

            _isChosen = value;

            OnPropertyChanged();
        }
    }

    public int Id
    {
        get => _id;

        private set
        {
            _id = value;
        }
    }

    public event Action<CharacterAvatarMV> CharacterPicked;

    [Binding]
    public void OnCharacterPressed()
    {
        CharacterPicked?.Invoke(this);
    }

    public void Initialize(int id)
    {
        Id = id;
    }
}
