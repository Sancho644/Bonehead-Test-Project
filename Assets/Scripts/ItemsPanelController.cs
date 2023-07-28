using System;
using UnityEngine;

public class ItemsPanelController : MonoBehaviour
{
    [SerializeField] private GameObject _itemsPanel;
    [SerializeField] private NewItemController _itemController;
    [SerializeField] private EquippedItemController _equippedItem;

    private int _itemPrice;
    private GameObject _item;

    public event Action<int> OnDropItem;
    public event Action<GameObject> OnEquipItem;

    public void SetItemStats(GameObject item)
    {
        if (item.TryGetComponent(out ItemStats stats))
        {
            _itemPrice = stats.Price;
            _item = item;
            
            UpdateEquippedItem(stats);
            UpdateNewItem(stats);
        }
    }

    private void UpdateEquippedItem(ItemStats stats)
    {
        var itemStats = EquippedItems.TakeItemStats(stats.Name);
        if (itemStats != null)
        {
            _equippedItem.SetEquippedItemStats(itemStats.Health, itemStats.Defence, itemStats.Attack, itemStats.Price, itemStats.Name, itemStats.Icon);
        }
        else
        {
            _equippedItem.SetEquippedStatus(false);
        }
    }

    private void UpdateNewItem(ItemStats stats)
    {
        _itemsPanel.gameObject.SetActive(true);
        _itemController.SetValues(stats.Health, stats.Defence, stats.Attack, stats.Price, stats.Name, stats.Icon);
    }

    public void OnClose()
    {
        _itemsPanel.gameObject.SetActive(false);
    }

    public void OnDrop()
    {
        OnClose();
        Destroy(_item);

        OnDropItem?.Invoke(_itemPrice);

        _itemPrice = 0;
    }

    public void OnEquip()
    {
        OnClose();
        OnEquipItem?.Invoke(_item);
    }
}