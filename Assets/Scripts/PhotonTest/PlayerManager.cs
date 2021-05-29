using System;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPun, IPunObservable
{
    public static GameObject LocalPlayerInstance;
    public static event Action<GameObject> LocalPlayerInstanceCreated;

    private UnitModel _model;

    public bool IsMine { get; private set; }

    public void Initialize(UnitModel model)
    {
        _model = model;

        model.Nickname = PhotonNetwork.NickName;
        model.UserId = PhotonNetwork.LocalPlayer.UserId;
    }

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
            if (IsMine)
            {
                string serializedModel = JsonUtility.ToJson(_model.SerializableModel);

                stream.SendNext(serializedModel);
            }
        }
        else
        {
            if (IsMine)
                return;

            string serializedModel = (string)stream.ReceiveNext();

            if (_model == null)
            {
                _model = new UnitModel();
                _model.SerializableModel = JsonUtility.FromJson<SerializableUnitModel>(serializedModel);
                UnitController.Instance.AddModel(_model);
            }
            else
            {
                _model.SerializableModel = JsonUtility.FromJson<SerializableUnitModel>(serializedModel);
            }
        }
    }
}
