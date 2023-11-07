using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    public class PlayerStat : MonoBehaviour
    {
        [SerializeField] PlayerStatData data;

        [SerializeField] int currentHp = 0;
        [SerializeField] int currentExp = 0;
        [SerializeField] PlayerInventory inventory;

        private void Awake()
        {
            currentHp = data.hp;

            inventory.onItemPickuped += OnItemPickuped;
        }

        private void OnDestroy()
        {
            inventory.onItemPickuped -= OnItemPickuped;
        }

        private void OnItemPickuped(ItemType itemType, int count)
        {
            switch (itemType)
            {
                case ItemType.Exp:
                    currentExp += 10;
                    break;

                case ItemType.BigExp:
                    currentExp += 100;
                    break;

                case ItemType.GreatExp:
                    currentExp += 1000;
                    break;
            }
        }
    }

}