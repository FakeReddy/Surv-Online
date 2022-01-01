using UnityEngine;
using Photon.Pun;
using TMPro;

public class NickNameView : MonoBehaviour, IPunObservable
{
    [SerializeField] private TMP_Text _nickName;

    private PhotonView _photonView;
    private Transform _target;
    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting == true)
        {
            stream.SendNext(PhotonNetwork.NickName);
        }
        else
        {
            _nickName.text = stream.ReceiveNext().ToString();
        }
    }

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        _nickName.text = PhotonNetwork.NickName;
    }

    private void Update()
    {
        transform.LookAt(_target);
    }

    public void SetLookAtTarget(ref Transform target)
    {
        if (target != null)
            _target = target;
    }
}