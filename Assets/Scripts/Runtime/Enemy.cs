using JLib.ObjectPool;
using JLib.ObjectPool.Addressables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyVampireSurvior
{
    public class Enemy : DefaultPoolObject
    {
        [SerializeField] EnemyStatData data;
        [SerializeField] int currentHp;
        [SerializeField] float moveSpeed;
        [SerializeField] Transform player;
        [SerializeField] ProjectileTarget projectileTarget;


        private void Awake()
        {
            projectileTarget.onHit += OnHit;
        }

        private void OnDestroy()
        {
            projectileTarget.onHit -= OnHit;
        }

        public void OnHit(int damage)
        {
            currentHp -= damage;
            if (currentHp <= 0)
            {
                DefaultObjectPoolWithAddressables.Instance.ReturnOne(key, this);
            }
        }

        public override void OnPoped()
        {
            base.OnPoped();
            currentHp = data.hp;
            moveSpeed = data.moveSpeed;

            var playerInput = FindFirstObjectByType<PlayerInput>();
            if(null == playerInput)
            {
                Debug.Log("Player input is null");
                return;
            }

            player = playerInput.transform;
        }

        public void Update()
        {
            if (null == player)
                return;

            var direction = player.transform.position - this.transform.position;
            direction.Normalize();

            this.transform.position += direction * moveSpeed * Time.deltaTime;
        }
    } 
}
