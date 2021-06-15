using System;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPun, IPunObservable
{
    private const string UnitConfigLocation = "Databases/UnitConfigurations";

    public static GameObject LocalPlayerInstance;
    public static event Action<GameObject> LocalPlayerInstanceCreated;

    private UnitModel _model;

    private UnitConfiguration[] _unitConfigurations;
    private UnitConfiguration[] UnitConfigurations
    {
        get
        {
            if (_unitConfigurations == null)
            {
                var unitConfigObject = Resources.Load<UnitConfigurations>(UnitConfigLocation);

                if (unitConfigObject)
                {
                    _unitConfigurations = unitConfigObject.unitConfigurations;
                }
                else
                {
                    Debug.LogError($"Error: failed loading UnitConfiguration with path {UnitConfigLocation}");
                }
            }

            return _unitConfigurations;
        }
    }
    
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
        else if (!IsMine)
        {
            string serializedModel = (string)stream.ReceiveNext();
            var sharedUnitModel = JsonUtility.FromJson<SerializableUnitModel>(serializedModel);

            if (_model == null)
            {
                CreateUnitModel(sharedUnitModel);
            }
            else
            {
                _model.SerializableModel = sharedUnitModel;
            }
        }
    }

    private void CreateUnitModel(SerializableUnitModel sharedUnitModel)
    {
        var config = GetUnitConfiguration(sharedUnitModel.UnitId);

        _model = new UnitModel(Vector3.zero, Vector3.zero, config);
        _model.SerializableModel = sharedUnitModel;

        UnitController.Instance.AddModel(_model);
    }

    public UnitConfiguration GetUnitConfiguration(int id)
    {
        foreach (var config in UnitConfigurations)
        {
            if (config.Id == id)
            {
                return config;
            }
        }

        return UnitConfiguration.Null;
    }
}
