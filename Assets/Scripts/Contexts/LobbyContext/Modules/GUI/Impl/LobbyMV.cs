using System;
using Photon.Pun;

using strange.extensions.context.api;

using UnityEngine;
using UnityEngine.SceneManagement;

using UnityWeld.Binding;

[Binding]
public class LobbyMV : CanvasMV
{
    public static event Action PlayClicked;

    private const string PlayerNameKey = "PlayerName";
    private bool _isChoosePanelActive;
    private string _playerName;

    private GameObject _currentHeroModel;

    [Inject] public ILobbyController LobbyController { get; set; }
    [Inject] public IUnitAnimationDatabase UnitAnimationDatabase { get; set; }
    [Inject] public CharacterChoosenSignal CharacterChoosenSignal { get; set; }
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject Root { get; set; }

    [Binding]
    public string PlayerName
    {
        get => _playerName;

        set
        {
            if (_playerName == value)
                return;

            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("LobbyMV: PlayerName property: tried to set null or empty string");
                return;
            }

            _playerName = value;
            
            PhotonNetwork.NickName = _playerName;
            PlayerPrefs.SetString(PlayerNameKey, _playerName);

            Debug.Log($"Player Name Changed to: " + _playerName);

            OnPropertyChanged();
        }
    }

    [Binding]
    public bool IsChoosePanelActive
    {
        get => _isChoosePanelActive;

        set
        {
            _isChoosePanelActive = value;

            OnPropertyChanged();
        }
    }

    [Binding]
    public void OnPlayClicked()
    {
        PlayClicked?.Invoke();
    }

    [Binding]
    public void ChangeHeroClicked()
    {
        IsChoosePanelActive = true;
    }

    [PostConstruct]
    private void Initialize()
    {
        CharacterChoosenSignal.AddListener(OnNewCharacterChosen);

        SpawnHero(LobbyController.Model.CurrentUnitId);
    }

    private void SpawnHero(int id)
    {
        GameObject characterPrefab = UnitAnimationDatabase.GetById(id).Model;

        if (characterPrefab)
        {
            Destroy(_currentHeroModel);

            _currentHeroModel = GameObject.Instantiate(characterPrefab, Root.transform);
            _currentHeroModel.transform.localScale = new Vector3(3, 3, 3);
            _currentHeroModel.transform.position = new Vector3(0, -2f, 0);
        }
        else
        {
            Debug.LogError($"LobbyMV: Couldn't find character model with id {id}");
        }
    }

    private void Start()
    {
        base.Start();

        PlayerName = LobbyController.Model.PlayerNickname;
    }

    private void OnNewCharacterChosen(int id)
    {
        IsChoosePanelActive = false;

        SpawnHero(id);
    }
}
