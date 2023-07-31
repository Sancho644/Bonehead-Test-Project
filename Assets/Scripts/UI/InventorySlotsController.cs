using Components;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotsController : MonoBehaviour
{
    [SerializeField] private Image _swordIcon;
    [SerializeField] private Image _shieldIcon;
    [SerializeField] private Image _helmetIcon;

    public void UpdateInventory(ItemTypes type, Sprite icon)
    {
        switch (type)
        {
            case ItemTypes.Helmet:
                _helmetIcon.sprite = icon;
                break;
            case ItemTypes.Sword:
                _swordIcon.sprite = icon;
                break;
            case ItemTypes.Shield:
                _shieldIcon.sprite = icon;
                break;
        }
    }
}