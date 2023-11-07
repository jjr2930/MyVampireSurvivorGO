using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyVampireSurvior
{
    public class ProjectileTarget : MonoBehaviour
    {
        public event Action<int> onHit;
        public void OnHit(int damage)
        {
            onHit?.Invoke(damage);
        }
    }
}