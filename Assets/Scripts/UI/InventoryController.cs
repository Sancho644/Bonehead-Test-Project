using System;
using Components;
using Model;
using UnityEngine;

namespace UI
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private StatsPanelController _statsPanel;
        [SerializeField] private SwordManController _swordMan;
        [SerializeField] private InventorySlotsController _inventorySlots;

        public event Action<int> OnEquipNewItem;

        private void Start()
        {
            SetStatsValues();
        }

        private void SetStatsValues()
        {
            _statsPanel.SetStats(_swordMan.Health, _swordMan.Defence, _swordMan.Attack);
        }

        public void UpdateSwordManStats(GameObject item)
        {
            if (item.TryGetComponent(out ItemStats stats))
            {
                UpdateEquippedList(item, stats);

                _swordMan.UpdateStats();
                _swordMan.UpdateLook(stats.Name);
                _inventorySlots.UpdateInventory(stats.Name, stats.Icon);

                SetStatsValues();
            }
        }

        private void UpdateEquippedList(GameObject item, ItemStats stats)
        {
            var equippedItem = EquippedItems.SearchSameItem(stats);

            if (equippedItem != null)
            {
                EquippedItems.EquippedItemsList.Add(item);
                item.SetActive(false);

                if (equippedItem.TryGetComponent(out ItemStats stat))
                    OnEquipNewItem?.Invoke(stat.Price);

                Destroy(equippedItem);
            }
            else
            {
                EquippedItems.EquippedItemsList.Add(item);
                item.SetActive(false);
            }
        }
    }
}