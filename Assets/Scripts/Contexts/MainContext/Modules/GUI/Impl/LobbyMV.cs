using System;
using Photon.Pun;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class LobbyMV : CanvasMV
{
    public static event Action PlayClicked;

    private const string PlayerNameKey = "PlayerName";
    private bool _isChoosePanelActive;
    private string _playerName;

    [Inject] public ILobbyController LobbyController { get; set; }
    [Inject] public IUnitDatabase UnitDatabase { get; set; }
    [Inject] public CharacterChoosenSignal CharacterChoosenSignal { get; set; }

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
    }

    private void Start()
    {
        base.Start();

        PlayerName = LobbyController.Model.PlayerLogin;
    }

    private void OnNewCharacterChosen(int id)
    {
        IsChoosePanelActive = false;

        Debug.Log($"LobbyMV: Current Unit ID: {LobbyController.Model.CurrentUnitId}");
    }
}
