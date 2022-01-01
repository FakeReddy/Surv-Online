using UnityEngine;
using Photon.Pun;

public class DeactivatorIfNotMine : MonoBehaviour
{
    [SerializeField] private bool _deactivate;
    [SerializeField] private bool _destroyOnStart;

    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        gameObject.SetActive(_photonView.IsMine != _deactivate);

        if (_destroyOnStart == true)
            Destroy(gameObject);
    }
}