using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components
{
    public class SwordManController : MonoBehaviour
    {
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Defence { get; private set; }
        [field: SerializeField] public int Attack { get; private set; }

        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _sword;
        [SerializeField] private GameObject _shield;
        [SerializeField] private GameObject _helmet;
        [SerializeField] private SpawnComponent _spawn;

        private Animations _animations;
        private const int HEALTH_VALUE = 10;
        private const int DEFENCE_VALUE = 3;
        private const int ATTACK_VALUE = 5;

        public void StartAnimation()
        {
            var animationsCount = Enum.GetNames(typeof(Animations)).Length;
            var random = Random.Range(0, animationsCount);
            var randomAnimation = Enum.GetName(typeof(Animations), random);

            _animator.Play(randomAnimation);
            _spawn.Spawn();
        }

        public void UpdateStats()
        {
            var statsList = new List<ItemStats>();

            var swordStats = EquippedItems.TakeItemStats(ItemTypes.Sword);
            var helmetStats = EquippedItems.TakeItemStats(ItemTypes.Helmet);
            var shieldStats = EquippedItems.TakeItemStats(ItemTypes.Shield);

            statsList.Add(swordStats);
            statsList.Add(helmetStats);
            statsList.Add(shieldStats);

            Health = HEALTH_VALUE;
            Defence = DEFENCE_VALUE;
            Attack = ATTACK_VALUE;

            foreach (var stat in statsList)
            {
                if (stat != null)
                {
                    Health += stat.Health;
                    Defence += stat.Defence;
                    Attack += stat.Attack;
                }
            }
        }

        public void UpdateLook(ItemTypes type)
        {
            switch (type)
            {
                case ItemTypes.Helmet:
                    _helmet.gameObject.SetActive(true);
                    break;
                case ItemTypes.Sword:
                    _sword.gameObject.SetActive(true);
                    break;
                case ItemTypes.Shield:
                    _shield.gameObject.SetActive(true);
                    break;
            }
        }
    }

    public enum Animations
    {
        Attack,
        Jump,
        Run,
        Sit
    }
}