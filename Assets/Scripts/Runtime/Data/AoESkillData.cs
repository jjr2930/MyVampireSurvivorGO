using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MyVampireSurvior
{
    public enum AoESkillShape 
    {
        Circle,
        Rectangle,
    }

    /// <summary>
    /// AoE : Area of Effect
    /// </summary>
    [CreateAssetMenu(menuName ="Data/AoE Skill Data")]
    public class AoESkillData : SkillData
    {
        public AoESkillShape shape;
        /// <summary>
        /// circle : use only x(radius), rectable use x, y
        /// </summary>
        public Vector2 size;
        public Vector2 offset;
        [Tooltip("0 = instant, other : Damage over time")]
        public float duration;
        public float Radius { get => size.x; }
        public float BoxWidth { get => size.x; }
        public float BoxHeight { get => size.y; }
    }
}