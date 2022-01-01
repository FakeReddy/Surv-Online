using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GetSetPlayerComponents _playerPrefab;
    [SerializeField] private SettingsView _settingsView;

    private void Awake()
    {
        Cursor.visible = false;
        GetSetPlayerComponents player = PhotonNetwork.Instantiate(_playerPrefab.name, Vector3.up, Quaternion.identity).GetComponent<GetSetPlayerComponents>();
        _settingsView.SetCameraMovmentComponent(player.GetCameraMovement());
        _settingsView.SetPlayerMovmentComponent(player.GetPlayerMovement());
        _settingsView.SetPlayerInputsComponent(player.GetPlayerInputs());
        _settingsView.SetPlayerJumpComponent(player.GetPlayerJump());
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
}