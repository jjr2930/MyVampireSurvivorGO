using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    public class PlayerStat : MonoBehaviour, IHpGettable
    {
        [SerializeField] PlayerStatData statData;
        [SerializeField] PlayerLevelUpTable levelUpTable;

        [SerializeField] int currentHp = 0;
        [SerializeField] int currentExperience = 0;
        [SerializeField] PlayerItemInventory inventory;
        [SerializeField] int currentLevel = 0;

        public float GetCurrentHpRate()
        {
            return currentHp / (float)statData.hp;
        }

        private void Awake()
        {
            currentHp = statData.hp;
            currentLevel = statData.startLevel;

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
                    currentExperience += 10;
                    break;

                case ItemType.BigExp:
                    currentExperience += 100;
                    break;

                case ItemType.GreatExp:
                    currentExperience += 1000;
                    break;
            }

            RefreshLevel();
        }

        void RefreshLevel()
        {
            while (levelUpTable.GetNextExperience(currentLevel) < currentExperience)
            {
                currentLevel++;
                Debug.Log($"Levelup! Now {currentLevel}");
            }
        }
    }
}