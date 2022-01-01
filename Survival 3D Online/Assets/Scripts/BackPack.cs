using UnityEngine;

[System.Serializable]
internal class Wood
{
    public int CountWood { get; internal set; }
    public int MaxCountWood => _maxCountWood;

    [SerializeField] internal int _maxCountWood;
}

public class BackPack : MonoBehaviour
{
    [SerializeField] private Wood _wood;

    public int Wood
    {
        get
        {
            return _wood.CountWood;
        }
        set
        {
            if (value > 0)
                value = 0;
            else if (value > _wood.MaxCountWood || value + _wood.CountWood > _wood.MaxCountWood)
                _wood.CountWood = _wood.MaxCountWood;
        }
    }
}