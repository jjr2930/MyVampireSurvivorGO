using System.Collections;
using UnityEngine;

namespace MyVampireSurvior
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] float delay = 1f;
        [SerializeField] float radius = 10f;
        [SerializeField] float nextSpawnTime;
        [SerializeField] PoolKey enemyKey;
        [SerializeField] Transform player;

        public void StartSpawn()
        {
            player = FindAnyObjectByType<PlayerInput>().transform;
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while (true)
            {
                var enemyOne = ObjectPool.Instance.PopOne(enemyKey);
                enemyOne.transform.position = GetRandomPosition() + player.transform.position;

                yield return new WaitForSeconds(delay);
            }
        }

        Vector3 GetRandomPosition()
        {
            float randomAngle = Random.Range(0f,360f);
            float x = Mathf.Cos(randomAngle) * radius;
            float y = Mathf.Sin(randomAngle) * radius;
            float z = 0;

            return new Vector3 (x, y, z);
        }
    }
}