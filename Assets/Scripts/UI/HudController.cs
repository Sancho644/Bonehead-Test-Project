using Components;
using UnityEngine;

namespace UI
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private ItemsPanelController _items;
        [SerializeField] private SelectionManager _selectionManager;
        [SerializeField] private InventoryController _inventoryController;
        [SerializeField] private PanelCoinsController _panelCoins;

        private void Start()
        {
            _selectionManager.OnRead += OnReadValues;
            _items.OnDropItem += OnSetCoins;
            _items.OnEquipItem += OnEquip;
            _inventoryController.OnEquipNewItem += OnSetCoins;
        }

        private void OnReadValues(GameObject item)
        {
            _items.SetItemStats(item);
        }

        private void OnSetCoins(int price)
        {
            _panelCoins.SetCoins(price);
        }

        private void OnEquip(GameObject item)
        {
            _inventoryController.UpdateSwordManStats(item);
        }

        private void OnDestroy()
        {
            _selectionManager.OnRead -= OnReadValues;
            _items.OnDropItem -= OnSetCoins;
            _items.OnEquipItem -= OnEquip;
            _inventoryController.OnEquipNewItem -= OnSetCoins;
        }
    }
}