using UnityEngine;

namespace Components
{
    public class ItemStats : MonoBehaviour
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Defence { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public ItemTypes Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public GameObject Item { get; private set; }

        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 6;

        private void Start()
        {
            SetStatsValue();
        }

        private void SetStatsValue()
        {
            int SetRandomValue()
            {
                return Random.Range(MIN_VALUE, MAX_VALUE);
            }

            Health = SetRandomValue();
            Defence = SetRandomValue();
            Attack = SetRandomValue();
            Price = SetRandomValue();
            Item = gameObject;
        }
    }

    public enum ItemTypes
    {
        Sword,
        Helmet,
        Shield
    }
}