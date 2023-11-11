using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyVampireSurvior
{
    [Serializable]
    public class PlayerLevelUpData
    {
        public int level;
        public int nextLevelExp;
    }

    [CreateAssetMenu(menuName ="Data/Player Level Up Table")]
    public class PlayerLevelUpTable : ScriptableObject
    {
        public List<PlayerLevelUpData> data = null;

        public int GetNextExperience(int level)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (level == data[i].level)
                {
                    return data[i].nextLevelExp;
                }
            }

            throw new InvalidOperationException($"can not found next exp, level : {level}");
        }
    }
}