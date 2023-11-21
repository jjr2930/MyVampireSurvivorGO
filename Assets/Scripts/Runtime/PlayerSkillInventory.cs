using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    public class PlayerSkillInventory : MonoBehaviour
    {
        [SerializeField]
        List<SkillData> skills = new List<SkillData>();

        public int Count { get => skills.Count; }

        public SkillData this[int index]
        {
            get
            {
                return skills[index];
            }
        }
    }
}