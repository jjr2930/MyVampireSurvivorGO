using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    public class PlayerSkillInventory : MonoBehaviour
    {
        public List<Skill> skills = new List<Skill>();

        public void DoTargetting(int index)
        {
            if (0 > index || skills.Count >= index)
                throw new System.IndexOutOfRangeException($"{index} is out of range");

            skills[index].DoTargetting((selectedTargets) 
                => 
                {

                });
        }
    }
}