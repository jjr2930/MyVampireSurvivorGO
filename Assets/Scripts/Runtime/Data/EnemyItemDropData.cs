using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    [Serializable]
    public struct RateInfo
    {
        public ItemType itemType;
        public int probability;
    }

    [CreateAssetMenu(menuName ="Data/Enemy Item Drop Data")]
    public class EnemyItemDropData : ScriptableObject
    {
        public List<RateInfo> data = new List<RateInfo>();
        public int totalProbability = 0;

        private void OnValidate()
        {
            int result = 0;
            for (int i = 0; i < data.Count; i++)
            {
                result += data[i].probability;
            }

            totalProbability = result;
        }

        /*
         * 1000
         * 10000
         * 500
         * 
         * 11499
         * 
         */
        public ItemType GetRandomItem()
        {
            int randomNumber = UnityEngine.Random.Range(0, totalProbability);

            //where is randomNumber
            int sum = 0;
            for (int i = 0; i < data.Count; i++)
            {
                sum += data[i].probability;
                if (randomNumber < sum)
                {
                    return data[i].itemType;
                }
            }

            //exception...
            Debug.Log("exception.. can not get random item, return default item");
            return ItemType.Exp;
        }
    }
}