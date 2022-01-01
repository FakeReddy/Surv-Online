using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public class SettingsView : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private Components _components;

    private void Awake()
    {
        _components._photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_components._photonView.IsMine == false) return;

        bool onEscape = _components._playerInputs.Escape;
        if (onEscape == true)
        {
            bool isNotActive = !_settingsMenu.activeSelf;
            Cursor.visible = !_settingsMenu.activeSelf;
            _settingsMenu.SetActive(!_settingsMenu.activeSelf);
            _components._playerMovement.IsControl = !_settingsMenu.activeSelf;
            _components._cameraMovement.IsControl = !_settingsMenu.activeSelf;
            _components._playerJump.IsControl = !_settingsMenu.activeSelf;
        }
    }

    public void SetCameraMovmentComponent(CameraMovement cameraMovement)
    {
        _components._cameraMovement = cameraMovement;
    }

    public void SetPlayerMovmentComponent(PlayerMovement playerMovement)
    {
        _components._playerMovement = playerMovement;
    }

    public void SetPlayerInputsComponent(PlayerInputs playerInputs)
    {
        _components._playerInputs = playerInputs;
    }

    public void SetPlayerJumpComponent(PlayerJump playerJump)
    {
        _components._playerJump = playerJump;
    }

    private struct Components
    {
        internal CameraMovement _cameraMovement;
        internal PlayerInputs _playerInputs;
        internal PlayerJump _playerJump;
        internal PlayerMovement _playerMovement;
        internal PhotonView _photonView;
    }
}