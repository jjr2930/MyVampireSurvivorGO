using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    public class Skill : MonoBehaviour
    {
        [SerializeField] protected SkillData skillData;
        [SerializeField] protected SkillTargetingType targetingType;

        public virtual void DoTargetting(Action<SkillTargetInfo[]> onTargetSelected)
        {
            throw new NotImplementedException(); 
        }

        public virtual void Do() 
        {
        }
    }
}