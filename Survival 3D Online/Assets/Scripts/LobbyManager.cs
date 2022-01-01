using UnityEngine;
using Photon.Pun;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InputFields _inputFields;

    private void Start()
    {
        PhotonNetwork.NickName = "Игрок " + Random.Range(1, 100);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        _animator.SetBool(GlobalStringsVars.IsLoadedAnim, true);
        /*
        _inputFields._namePlayer.text = "gagagij";
        _inputFields._nameCreateRoom.text = "1";
        CreateRoom();*/
    }

    public void CreateRoom()
    {
        if (_inputFields._nameCreateRoom.text != "" && _inputFields._namePlayer.text != "")
        {
            PhotonNetwork.CreateRoom(_inputFields._nameCreateRoom.text, new Photon.Realtime.RoomOptions { MaxPlayers = 5 });
            PhotonNetwork.NickName = _inputFields._namePlayer.text;
        }
    }

    public void JoinRoom()
    {
        if (_inputFields._nameJoinRoom.text != "" && _inputFields._namePlayer.text != "")
        {
            PhotonNetwork.JoinRoom(_inputFields._nameJoinRoom.text);
            PhotonNetwork.NickName = _inputFields._namePlayer.text;
        }
    }

    public void JoinRandomRoom()
    {
        if (_inputFields._namePlayer.text != "")
        {
            PhotonNetwork.JoinRandomRoom();
            PhotonNetwork.NickName = _inputFields._namePlayer.text;
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    [System.Serializable]
    private struct InputFields
    {
        [SerializeField] internal TMP_InputField _nameCreateRoom;
        [SerializeField] internal TMP_InputField _nameJoinRoom;
        [SerializeField] internal TMP_InputField _namePlayer;
    }
}