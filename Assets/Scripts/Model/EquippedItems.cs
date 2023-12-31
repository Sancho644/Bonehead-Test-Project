﻿using System.Collections.Generic;
using Components;
using UnityEngine;

namespace Model
{
    public static class EquippedItems
    {
        public static readonly List<GameObject> EquippedItemsList = new();

        private static GameObject _item;

        public static GameObject SearchSameItem(ItemStats itemStats)
        {
            foreach (var item in EquippedItemsList)
            {
                if (item.TryGetComponent(out ItemStats stats))
                {
                    if (stats.Name == itemStats.Name)
                    {
                        EquippedItemsList.Remove(item);

                        return item;
                    }
                }
            }

            return null;
        }

        public static ItemStats TakeItemStats(ItemTypes type)
        {
            foreach (var item in EquippedItemsList)
            {
                if (item.TryGetComponent(out ItemStats stats))
                {
                    if (stats.Name == type)
                    {
                        return stats;
                    }
                }
            }

            return null;
        }
    }
}