using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(CharacterController), typeof(PhotonView))]
public class PlayerGravity : MonoBehaviour
{
    public bool IsGrounded { get; private set; } = true;
    public bool IsGravity { get; set; }

    [SerializeField] private float _gravity = 0.12f;
    [SerializeField] private LayerMask _ground;

    private float _velocityFall;


    private CharacterController _characterController;
    private PhotonView _photonView;
    private float _radiusCheckSphere = 0.2f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_photonView.IsMine == false) return;

        IsGrounded = Physics.CheckSphere(transform.position, _radiusCheckSphere, _ground);


        if (IsGrounded == false && IsGravity == true)
        {
            _velocityFall += _gravity;
            _characterController.Move(Vector3.down * (_velocityFall * Time.deltaTime));
        }
        else
            _velocityFall = 0;
    }
}