using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyVampireSurvior
{
    public delegate void OnItemPickupDelegate(ItemType itemType, int count);

    public class PlayerInventory : MonoBehaviour
    {
        public event OnItemPickupDelegate onItemPickuped;

        /// <summary>
        /// key : item type , value : count
        /// </summary>
        Dictionary<ItemType, int> itemCountByType = new Dictionary<ItemType, int>();

        public Dictionary<ItemType, int> ItemCountByType
        {
            get { return itemCountByType; }
        }

        private void Awake()
        {
            for(ItemType type = ItemType.None + 1;  
                type <= ItemType.Count;
                ++type)
            {
                itemCountByType[type] = 0;
            }
        }

        public void AddItem(ItemType type)
        {
            if (false == itemCountByType.ContainsKey(type))
            {
                itemCountByType[type] = 0;
            }
            else
                itemCountByType[type]++;

            onItemPickuped?.Invoke(type, 1);
        }

        public void RemoveItem(ItemType type)
        {
            if(itemCountByType.ContainsKey(type))
            {
                itemCountByType[type]--;
            }
        }
    }
}