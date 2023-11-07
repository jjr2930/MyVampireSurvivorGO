using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    [CreateAssetMenu(menuName = "Data/Projectile Data")]
    public class ProjectileData : ScriptableObject
    {
        public float moveSpeed;
        public int damage;

        [Range(0f, 1f)]
        public float guideRate;
    }
}