using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerInputs))]
public class GetSetPlayerComponents : MonoBehaviour
{
    [SerializeField] private Components _components;

    private void Awake()
    {
        _components._playerMovement = GetComponent<PlayerMovement>();
        _components._playerInputs = GetComponent<PlayerInputs>();
        _components._playerJump = GetComponent<PlayerJump>();
        Transform thisTransform = GetComponent<Transform>();
        _components._nickNameView.SetLookAtTarget(ref thisTransform);
    }

    public CameraMovement GetCameraMovement()
    {
        return _components._cameraMovement;
    }

    public PlayerMovement GetPlayerMovement()
    {
        return _components._playerMovement;
    }

    public PlayerInputs GetPlayerInputs()
    {
        return _components._playerInputs;
    }

    public PlayerJump GetPlayerJump()
    {
        return _components._playerJump;
    }

    public void SetTargetNickName(ref Transform target)
    {

    }

    [System.Serializable]
    private struct Components
    {
        [SerializeField] internal CameraMovement _cameraMovement;
        [SerializeField] internal NickNameView _nickNameView;

        internal PlayerMovement _playerMovement;
        internal PlayerInputs _playerInputs;
        internal PlayerJump _playerJump;
    }
}