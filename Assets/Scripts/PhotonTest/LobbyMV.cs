using System;

using Photon.Pun;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class LobbyMV : CanvasMV
{
    public static event Action PlayClicked;

    private const string PlayerNameKey = "PlayerName";
    private string _playerName;

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
    public void OnPlayClicked()
    {
        PlayClicked?.Invoke();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            PlayerName = PlayerPrefs.GetString(PlayerNameKey);
        }
        else
        {
            PlayerName = "Player";
        }
    }
}
