using System.Collections.Generic;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class ChooseCharaterMV : CanvasMV
{
    private const string AvatarPrefabLocation = "GUI/CharacterAvatarMV";

    private GameObject _avatarPrefab;
    private List<CharacterAvatarMV> _avatars = new List<CharacterAvatarMV>(5);
    private CharacterAvatarMV _chosenAvatar;

    [SerializeField] private Transform _contentTransform;

    [Inject] public CharacterChoosenSignal CharacterChoosenSignal { get; set; }
    [Inject] public IUnitDatabase UnitDatabase { get; set; }

    private GameObject AvatarPrefab
    {
        get
        {
            if (_avatarPrefab == null)
            {
                _avatarPrefab = Resources.Load<GameObject>(AvatarPrefabLocation);

                if (_avatarPrefab == null)
                {
                    Debug.LogError($"Error: cannot load prefab by location: {AvatarPrefabLocation}");
                }
            }

            return _avatarPrefab;
        }
    }

    [Binding]
    public void ChooseButtonPressed()
    {
        Debug.Log($"CHARACTER ID: {_chosenAvatar.Id}");
        CharacterChoosenSignal.Dispatch(_chosenAvatar.Id);
    }

    [PostConstruct]
    private void Initialize()
    {
        foreach (var config in UnitDatabase.Configs)
        {
            var newAvatar = Instantiate(AvatarPrefab, _contentTransform);

            if (newAvatar.TryGetComponent(out CharacterAvatarMV avatarMV))
            {
                avatarMV.Initialize(config.Id);
                avatarMV.CharacterPicked += OnCharacterPicked;

                _avatars.Add(avatarMV);
            }
            else
            {
                Debug.LogError("Error: Couldn't GetComponent from ChatacterAvatarMV");
            }
        }
    }

    private void OnCharacterPicked(CharacterAvatarMV chosenAvatar)
    {
        if (_chosenAvatar)
        {
            _chosenAvatar.IsChosen = false;
        }

        _chosenAvatar = chosenAvatar;
        _chosenAvatar.IsChosen = true;
    }
}
