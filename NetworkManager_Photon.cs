// Assets/Scripts/Network/NetworkManager_Photon.cs
using UnityEngine;
#if PHOTON_PUN
using Photon.Pun;
using Photon.Realtime;
#endif

public class NetworkManager_Photon : MonoBehaviour
{
    public static NetworkManager_Photon Instance;

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

#if PHOTON_PUN
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom(string roomName, byte maxPlayers = 4)
    {
        RoomOptions opt = new RoomOptions { MaxPlayers = maxPlayers };
        PhotonNetwork.CreateRoom(roomName, opt);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void JoinOrCreateRandom() { PhotonNetwork.JoinRandomRoom(); }
#endif
}
