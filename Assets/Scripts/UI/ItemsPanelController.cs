using System;
using Components;
using Model;
using UnityEngine;

namespace UI
{
    public class ItemsPanelController : MonoBehaviour
    {
        [SerializeField] private GameObject _itemsPanel;
        [SerializeField] private NewItemController _itemController;
        [SerializeField] private EquippedItemController _equippedItem;
        [SerializeField] private DropObjectsCount _dropObjects;
        [SerializeField] private NewItemStatsController _newItemStatsController;
        [SerializeField] private SelectionManager _selectionManager;

        private bool _hasEquippedItem;
        private int _itemPrice;
        private GameObject _item;
        private ItemStats _newItemStats;
        private ItemStats _equippedItemStats;

        public event Action<int> OnDropItem;
        public event Action<GameObject> OnEquipItem;

        public void SetItemStats(GameObject item)
        {
            if (item.TryGetComponent(out ItemStats stats))
            {
                _newItemStats = stats;
                _itemPrice = stats.Price;
                _item = item;
                _newItemStatsController.UpdateIcons();

                UpdateEquippedItem(stats);
                UpdateItemPanel(stats);
                UpdateManager(false);
            }
        }

        private void UpdateEquippedItem(ItemStats stats)
        {
            var itemStats = EquippedItems.TakeItemStats(stats.Name);
            _equippedItemStats = itemStats;

            if (itemStats != null)
            {
                _hasEquippedItem = true;
                _equippedItem.SetEquippedItemStats(itemStats.Health, itemStats.Defence, itemStats.Attack,
                    itemStats.Price,
                    itemStats.Name, itemStats.Icon);
            }
            else
            {
                _equippedItem.SetEquippedStatus(false);
                _hasEquippedItem = false;
            }
        }

        private void UpdateItemPanel(ItemStats stats)
        {
            _itemsPanel.gameObject.SetActive(true);
            _itemController.SetValues(stats.Health, stats.Defence, stats.Attack, stats.Price, stats.Name, stats.Icon);

            if (!_hasEquippedItem) return;

            if (_newItemStats.Health != _equippedItemStats.Health)
                _newItemStatsController.SetHealthDifference(_newItemStats.Health > _equippedItemStats.Health);

            if (_newItemStats.Attack != _equippedItemStats.Attack)
                _newItemStatsController.SetAttackDifference(_newItemStats.Attack > _equippedItemStats.Attack);

            if (_newItemStats.Defence != _equippedItemStats.Defence)
                _newItemStatsController.SetDefenceDifference(_newItemStats.Defence > _equippedItemStats.Defence);
        }

        public void OnClose()
        {
            _itemsPanel.gameObject.SetActive(false);
            UpdateManager(true);
        }

        private void UpdateManager(bool value)
        {
            _selectionManager.ManagerSwitcher(value);
        }

        public void OnDrop()
        {
            OnClose();

            if (_newItemStats != null)
            {
                _dropObjects.SetObjectCount(_newItemStats.Price);
                _dropObjects.CalculateDrop();
            }

            UpdateManager(true);
            Destroy(_item);
            OnDropItem?.Invoke(_itemPrice);

            _itemPrice = 0;
        }

        public void OnEquip()
        {
            UpdateManager(true);
            OnClose();
            OnEquipItem?.Invoke(_item);
        }
    }
}