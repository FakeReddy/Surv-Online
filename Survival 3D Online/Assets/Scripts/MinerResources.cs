using UnityEngine;

[RequireComponent(typeof(BackPack))]
public class MinerResources : PlayerInputs
{
    [SerializeField] private float _distanceToMine;

    private BackPack _backPack;
    private RaycastHit _rayHit;
    private float _progress;

    private void Awake()
    {
        _backPack = GetComponent<BackPack>();
    }

    private void Update()
    {
        bool mouse0 = Mouse0;

        if (mouse0 && Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f)), out _rayHit, _distanceToMine) && _rayHit.transform.gameObject.TryGetComponent<Mineable>(out Mineable mineable))
        {
            _progress += Time.deltaTime;
            if(_progress > mineable.GetSecondsMine())
            {
                Debug.Log(_progress);
                _progress = 0;
            }
        }
        else
        {
            _progress = 0;
        }
    }
}