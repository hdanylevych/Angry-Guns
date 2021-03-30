using System.Collections.Generic;
using UnityEngine;

public class ChooseCharaterMV : CanvasMV
{
    private const string AvatarPrefabLocation = "GUI/CharacterAvatarMV";

    private GameObject _avatarPrefab;
    private List<CharacterAvatarMV> _avatars = new List<CharacterAvatarMV>(5);

    [SerializeField] private Transform _content;

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

    [PostConstruct]
    private void Initialize()
    {
        foreach (var config in UnitDatabase.Configs)
        {
            var newAvatar = Instantiate(AvatarPrefab, _content);

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

    private void OnCharacterPicked(int id)
    {
        Debug.Log($"CHARACTER ID: {id}");
        CharacterChoosenSignal.Dispatch(id);
    }
}
