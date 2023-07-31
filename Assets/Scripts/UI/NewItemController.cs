using Components;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NewItemController : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _healthValue;
        [SerializeField] private Text _defenceValue;
        [SerializeField] private Text _attackValue;
        [SerializeField] private Text _itemName;
        [SerializeField] private Text _priceValue;

        public void SetValues(int hp, int def, int atk, int price, ItemTypes itemName, Sprite icon)
        {
            _healthValue.text = hp.ToString();
            _defenceValue.text = def.ToString();
            _attackValue.text = atk.ToString();
            _priceValue.text = price.ToString();
            _itemName.text = itemName.ToString();
            _icon.sprite = icon;
        }
    }
}