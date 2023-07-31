using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components
{
    public class DropObjectsCount : MonoBehaviour
    {
        [SerializeField] private int _countOfObjects;
        [SerializeField] private bool _spawnOnEnable;
        [SerializeField] private bool _randomSpawn;
        [SerializeField] private GameObject[] _dropObjects;

        private int _itemTypesCount;
        private ItemTypes _itemType;
        private const int DROP_REPEATE_VALUE = 3;

        public event Action<GameObject[]> OnDropCalculated;

        private void Start()
        {
            if (_spawnOnEnable)
                CalculateDrop();
        }

        [ContextMenu("CalculateDrop")]
        public void CalculateDrop()
        {
            if (!_randomSpawn)
            {
                var itemsCount = _countOfObjects;
                var itemsToDrop = new GameObject[itemsCount];

                for (int i = 0; i < itemsCount; i++)
                {
                    itemsToDrop[i] = _dropObjects[0];
                }

                OnDropCalculated?.Invoke(itemsToDrop);
            }
            else
            {
                var dropObject = new[] { TakeRandomItem() };

                OnDropCalculated?.Invoke(dropObject);
            }
        }

        public void SetObjectCount(int value)
        {
            _countOfObjects = value;
        }

        private GameObject TakeRandomItem()
        {
            while (true)
            {
                var randomObject = _dropObjects[Random.Range(0, _dropObjects.Length)];

                if (randomObject.TryGetComponent(out ItemStats stats))
                {
                    if (_itemType == stats.Name)
                        _itemTypesCount++;

                    _itemType = stats.Name;

                    if (_itemTypesCount >= DROP_REPEATE_VALUE)
                        continue;

                    return randomObject;
                }

                break;
            }

            return null;
        }
    }
}