using System;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPun, IPunObservable
{
    public static GameObject LocalPlayerInstance;
    public static event Action<GameObject> LocalPlayerInstanceCreated;

    public bool IsMine { get; private set; }

    private void Start()
    {
        if (photonView.IsMine)
        {
            IsMine = true;
            LocalPlayerInstance = gameObject;
            LocalPlayerInstanceCreated?.Invoke(LocalPlayerInstance);
        }

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode loadingMode)
    {
        // check if we are outside the Arena and if it's the case, spawn around the center of the arena in a safe zone
        if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
        {
            transform.position = new Vector3(0f, 5f, 0f);
        }
    }

    public void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
        }
        else
        {
            
        }
    }
}
