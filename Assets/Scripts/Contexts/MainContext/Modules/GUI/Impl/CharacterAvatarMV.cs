using System;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class CharacterAvatarMV : CanvasMV
{
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

    public int Id
    {
        get => _id;

        private set
        {
            _id = value;
        }
    }

    public event Action<int> CharacterPicked;

    [Binding]
    public void OnCharacterPressed()
    {
        CharacterPicked?.Invoke(Id);
    }

    public void Initialize(int id)
    {
        Id = id;
    }
}
