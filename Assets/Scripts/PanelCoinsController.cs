using UnityEngine;
using UnityEngine.UI;

public class PanelCoinsController : MonoBehaviour
{
    [SerializeField] private Text _panelCoins;

    private int _coins;
    
    public void SetCoins(int value)
    {
        _coins += value;
        _panelCoins.text = _coins.ToString();
    }
}