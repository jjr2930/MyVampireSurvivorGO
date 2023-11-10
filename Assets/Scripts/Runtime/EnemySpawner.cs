using UnityEngine;

namespace MyVampireSurvior
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        float delay = 1f;

        [SerializeField]
        float radius = 10f;

        [SerializeField]
        float nextSpawnTime;

        [SerializeField]
        PoolKey enemyKey;

        void Update()
        {
            if(Time.time >= nextSpawnTime)
            {
                nextSpawnTime += delay;
                var enemyOne = ObjectPool.Instance.PopOne(enemyKey);
                enemyOne.transform.position = GetRandomPosition();
            }
        }

        Vector3 GetRandomPosition()
        {
            float randomAngle = Random.Range(0f,360f);
            float x = Mathf.Sin(randomAngle) * radius;
            float y = Mathf.Cos(randomAngle) * radius;
            float z = 0;

            return new Vector3 (x, y, z);
        }
    }
}