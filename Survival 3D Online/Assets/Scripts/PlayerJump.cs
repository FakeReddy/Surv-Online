using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(CharacterController), typeof(PlayerGravity))]
public class PlayerJump : PlayerInputs
{
    public bool IsControl { get; set; } = true;

    [SerializeField] private float _height;
    [SerializeField] private float _force = 0.25f;
    [SerializeField] private bool _isJump;

    private Components _components;
    private float _velocity;

    private void Awake()
    {
        _components._characterController = GetComponent<CharacterController>();
        _components._playerGravity = GetComponent<PlayerGravity>();
        _components._photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_components._photonView.IsMine == false) return;
        bool isJump = Space;

        if (isJump == true && _components._playerGravity.IsGrounded == true && _isJump == false)
        {
            _isJump = true;
            _components._playerGravity.IsGravity = false;
        }
        if(_isJump == true)
        {
            Jump();
        }
    }

    private void Jump()
    {
        if(_velocity <= 0)
        {
            _components._playerGravity.IsGravity = true;
            _isJump = false;
            _velocity = _height;
            return;
        }
        _velocity -= _force;
        _components._characterController.Move(Vector3.up * (_velocity * Time.deltaTime));
    }

    private struct Components
    {
        internal CharacterController _characterController;
        internal PlayerGravity _playerGravity;
        internal PhotonView _photonView;
    }
}