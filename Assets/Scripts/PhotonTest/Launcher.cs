using System;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    private const string GameVersion = "1";
    private bool isConnecting;

    [SerializeField] private byte _maxPlayersInRoom = 8;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        LobbyMV.PlayClicked += Connect;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Debug.Log("CountOfPlayersInRooms: " + PhotonNetwork.CountOfPlayersInRooms);
            Debug.Log("CountOfRooms: " + PhotonNetwork.CountOfRooms);
        }
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = GameVersion;
        }
    }

    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");

        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = _maxPlayersInRoom });
    }

    public override void OnJoinedRoom()
    {
        // #Critical: We only load if we are the first player, else we rely on `PhotonNetwork.AutomaticallySyncScene` to sync our instance scene.
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("We load the 'Battle' ");


            // #Critical
            // Load the Room Level.
            PhotonNetwork.LoadLevel("Battle", LoadSceneMode.Additive);
        }
    }

    private void OnDestroy()
    {
    }
}
