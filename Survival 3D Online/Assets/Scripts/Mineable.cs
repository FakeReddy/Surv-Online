using UnityEngine;

public class Mineable : MonoBehaviour
{
    [SerializeField] private int _countGetResources;
    [SerializeField] private float _secondsMine;

    public int GetResources()
    {
        return _countGetResources;
    }

    public float GetSecondsMine()
    {
        return _secondsMine;
    }
}