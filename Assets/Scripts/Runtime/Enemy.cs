using JLib.ObjectPool;
using JLib.ObjectPool.Addressables;
using System;
using UnityEngine;
using ObjectPool = JLib.ObjectPool.Addressables.DefaultObjectPoolWithAddressables;

namespace MyVampireSurvior
{
    public class Enemy : DefaultPoolObject , IHpGettable
    {
        [SerializeField] EnemyStatData statData;
        [SerializeField] EnemyItemDropData dropData;
        [SerializeField] int currentHp;
        [SerializeField] float moveSpeed;
        [SerializeField] Transform player;
        [SerializeField] ProjectileTarget projectileTarget;
        [SerializeField] DefaultKey fieldItemKey;

        HpSliderManager sliderManager;
        public HpSliderManager SliderManager
        {
            get
            {
                if(null == sliderManager)
                {
                    sliderManager = FindObjectOfType<HpSliderManager>();    
                    if(null == sliderManager)
                    {
                        throw new InvalidOperationException("there is no sliderManager");
                    }
                }

                return sliderManager;
            }
        }
        private void Awake()
        {
            projectileTarget.onHit += OnHit;
        }

        public void Update()
        {
            if (null == player)
                return;

            var direction = player.transform.position - this.transform.position;
            direction.Normalize();

            this.transform.position += direction * moveSpeed * Time.deltaTime;
        }

        private void OnDestroy()
        {
            projectileTarget.onHit -= OnHit;
        }

        public void OnHit(int damage)
        {
            //already dead...
            if (currentHp <= 0)
            {
                return;
            }

            currentHp -= damage;
            if (currentHp <= 0)
            {
                //Debug.Log($"instance id : {gameObject.GetInstanceID()} will be dead");
                ObjectPool.Instance.ReturnOne(key, this);

                //drop random item
                var randomItem = dropData.GetRandomItem();
                var fieldItemPoolObject = ObjectPool.Instance.PopOne(fieldItemKey);
                var fieldItem = fieldItemPoolObject.GetComponent<FieldItem>();
                fieldItem.ItemType = randomItem;
                fieldItem.transform.position = this.transform.position;
            }
        }

        public override void OnPoped()
        {
            base.OnPoped();
            currentHp = statData.hp;
            moveSpeed = statData.moveSpeed;

            var playerInput = FindFirstObjectByType<PlayerInput>();
            if(null == playerInput)
            {
                Debug.Log("Player input is null");
                return;
            }

            player = playerInput.transform;

            //Debug.Log("Request Addone id : " + gameObject.GetInstanceID());
            SliderManager.AddOne(this);
        }

        public override void OnReturned()
        {
            base.OnReturned();

            //Debug.Log("Request RemoveOne id : " + gameObject.GetInstanceID());
            SliderManager.RemoveOne(this);
        }

        public float GetCurrentHpRate()
        {
            return currentHp / (float)statData.hp;
        }
    } 
}
