using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(CharacterController), typeof(ActorView), typeof(PhotonView))]
public class PlayerMovement : PlayerInputs
{
    public bool IsControl { get; set; } = true;

    [SerializeField] private float  _speed;

    private Components _components;

    private void Awake()
    {
        _components._characterController = GetComponent<CharacterController>();
        _components._actorView = GetComponent<ActorView>();
        _components._photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_components._photonView.IsMine == false) return;

        float horizontal = Horizontal;
        float vertical = Vertical;
        Vector3 directionFromWorld = Vector3.right * horizontal + Vector3.forward * vertical;
        Vector3 directionFromCharacter = transform.right * horizontal + transform.forward * vertical;
        if (IsControl == true)
        {
            SetWalkAnimToDirection(directionFromWorld);

            if (directionFromCharacter.magnitude != 0)
            {
                _components._characterController.Move(directionFromCharacter.normalized * (_speed * Time.deltaTime));
            }
        }
    }

    private void SetWalkAnimToDirection(Vector3 direction)
    {
        direction = direction.normalized;
        _components._actorView.SetForwardValue(direction.z);
        _components._actorView.SetRightwardValue(direction.x);
    }

    private struct Components
    {
        internal CharacterController _characterController;
        internal ActorView _actorView;
        internal PhotonView _photonView;
    }
}