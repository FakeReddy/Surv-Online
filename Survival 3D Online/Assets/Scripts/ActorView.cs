using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Animator))]
public class ActorView : MonoBehaviour, IPunObservable
{
    private Animator _animator;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting == true)
        {
            stream.SendNext(_animator.GetFloat(GlobalStringsVars.ForwardAnim));
            stream.SendNext(_animator.GetFloat(GlobalStringsVars.RightwardAnim));
        }
        else
        {
            SetForwardValue((float)stream.ReceiveNext());
            SetRightwardValue((float)stream.ReceiveNext());
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetForwardValue(float value)
    {
        _animator.SetFloat(GlobalStringsVars.ForwardAnim, value);
    }

    public void SetRightwardValue(float value)
    {
        _animator.SetFloat(GlobalStringsVars.RightwardAnim, value);
    }
}