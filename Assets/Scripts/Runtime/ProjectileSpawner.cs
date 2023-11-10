using System;
using JLib.ObjectPool.Addressables;
using UnityEngine;

namespace MyVampireSurvior
{
	public class ProjectileSpawner : MonoBehaviour
	{
        [SerializeField] ScriptableObject fireData;
        [SerializeField] float searchingRadius;
        [SerializeField] float nextSpawnTime = 0f;
        [SerializeField] PoolKey key;
        [SerializeField] LayerMask targetLayer;

        ISpawnableData spawnableData;

        private void Awake()
        {
            if (fireData is ISpawnableData)
            {
                spawnableData = (ISpawnableData)fireData;
            }
            else
            {
                throw new InvalidOperationException("fire data is not inherited ISpawnableData");
            }
        }

        private void Update()
        {
            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime = Time.time + spawnableData.FireDelay;

                var colliders = Physics2D.OverlapCircleAll(transform.position , searchingRadius, targetLayer);
                if (colliders.Length > 0)
                {
                    float minDistance = float.MaxValue;
                    Transform minTransform = null;

                    for (int i = 0; i < colliders.Length; i++)
                    {
                        var distance = Vector2.Distance(colliders[i].transform.position, transform.position);
                        if(minDistance > distance)
                        {
                            minDistance = distance;
                            minTransform = colliders[i].transform;
                        }
                    }

                    if (minTransform != null)
                    {
                        var one = ObjectPool.Instance.PopOne(key);
                        var projectile = one.GetComponent<Projectile>();
                        projectile.transform.position = this.transform.position;
                        projectile.SetOwner(this.gameObject);
                        projectile.SetTarget(minTransform);
                    }
                }
            }
        }
    }
}