using Components;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EquippedItemController : MonoBehaviour
    {
        [SerializeField] private Text _itemName;
        [SerializeField] private Text _itemHeatlh;
        [SerializeField] private Text _itemAttack;
        [SerializeField] private Text _itemDefence;
        [SerializeField] private Text _itemPrice;
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _nonEquipped;
        [SerializeField] private GameObject _equippedContainer;

        public void SetEquippedItemStats(int hp, int def, int atk, int price, ItemTypes itemName, Sprite icon)
        {
            _itemName.text = itemName.ToString();
            _itemHeatlh.text = hp.ToString();
            _itemAttack.text = atk.ToString();
            _itemDefence.text = def.ToString();
            _itemPrice.text = price.ToString();
            _icon.sprite = icon;

            SetEquippedStatus(true);
        }

        public void SetEquippedStatus(bool status)
        {
            _equippedContainer.gameObject.SetActive(status);
            _nonEquipped.gameObject.SetActive(!status);
        }
    }
}