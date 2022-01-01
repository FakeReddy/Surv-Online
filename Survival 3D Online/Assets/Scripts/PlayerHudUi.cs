using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHudUi : MonoBehaviour
{
    [SerializeField] private Texts _texts;
    
    private BackPack _backPack;
    private Image _progressBar;

    private void Awake()
    {
        _backPack = GetComponent<BackPack>();
    }

    public void UpdateWoodText()
    {
        if (_backPack.Wood >= 0)
            _texts._countWood.text = GlobalStringsVars.WoodText + _backPack.Wood.ToString();
    }

    public void SetImageProgressBar(Image progressBar)
    {
        _progressBar = progressBar;
    }

    private struct Texts
    {
        [SerializeField] internal TMP_Text _countWood;
    }
}