using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropObjectsCount : MonoBehaviour
{
    [SerializeField] private ItemStats _itemStats;
    [SerializeField] private bool _spawnOnEnable;
    [SerializeField] private GameObject[] _dropObjects;

    private int _itemTypesCount;
    private ItemTypes _itemType;
    private const int DROP_REPEATE_VALUE = 3;
    
    public event Action<GameObject[]> OnDropCalculated;

    private void Start()
    {
        if (_spawnOnEnable)
        {
            CalculateDrop();
        }
    }
    
    private void CalculateDrop()
    {
        if (_itemStats != null)
        {
            var itemsCount = _itemStats.Price;
            var itemsToDrop = new GameObject[itemsCount];
            
            for (int i = 0; i < itemsCount; i++)
            {
                itemsToDrop[i] = _dropObjects[0];
            }
            
            OnDropCalculated?.Invoke(itemsToDrop);
        }
        else
        {
            var dropObject = new GameObject[TakeRandomItem()];
            
            OnDropCalculated?.Invoke(dropObject);
        }
    }

    private int TakeRandomItem()
    {
        while (true)
        {
            var randomObject = Random.Range(0, _dropObjects.Length);

            if (_dropObjects[randomObject].TryGetComponent(out ItemStats stats))
            {
                if (_itemType == stats.Name)
                {
                    _itemTypesCount++;
                }

                _itemType = stats.Name;

                if (_itemTypesCount >= DROP_REPEATE_VALUE)
                {
                    continue;
                }

                return randomObject;
            }

            break;
        }

        return 0;
    }
}