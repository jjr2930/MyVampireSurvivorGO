using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MyVampireSurvior
{
    public enum SkillType
    {
        Instant,
        InstantAoE,
        Dot,
        DotAoE,
    }

    public class SkillData : ScriptableObject
    {
        //total damage
        public int damage;
        public SkillType skillType;
        public AssetReference icon;
    }
}