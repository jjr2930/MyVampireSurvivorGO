using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    [CreateAssetMenu(menuName ="Data/Enemy Stat")]
    public class EnemyStatData : ScriptableObject, ISpawnableData
    {
        public int hp;
        public int moveSpeed;
        public float fireDelay;
        public float FireDelay => fireDelay;
    }
}