using System.Collections;
using UnityEngine;
using ObjectPool = JLib.ObjectPool.Addressables.DefaultObjectPoolWithAddressables;

namespace MyVampireSurvior
{
    public class Projectile : JLib.ObjectPool.DefaultPoolObject
    {
        [SerializeField]
        ProjectileData data;

        [SerializeField]
        GameObject owner;

        [SerializeField]
        Transform target = null;

        [SerializeField]
        Vector3 lastDirection = Vector3.zero;

        [SerializeField]
        float selfReturnTime = 10f;

        Coroutine selfReturnCoroutine = null;

        public void SetOwner(GameObject owner)
        {
            this.owner = owner;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
            lastDirection = target.position - this.transform.position;
            lastDirection.Normalize();
        }

        private void Update()
        {
            Vector3 direction = Vector3.zero;
            if (target == null || false == target.gameObject.activeInHierarchy)
            {
                direction = lastDirection;
            }
            else
            {
                direction = target.position - this.transform.position;
            }

            direction.Normalize();

            lastDirection = Vector3.Slerp(lastDirection, direction, data.guideRate);

            transform.position += lastDirection * data.moveSpeed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var projectileTarget = collision.gameObject.GetComponent<ProjectileTarget>();
            if (null == projectileTarget)
                return;

            if (collision.gameObject == this.owner)
                return;


            projectileTarget.OnHit(data.damage);
            ObjectPool.Instance.ReturnOne(key, this);
        }

        public override void OnPoped()
        {
            base.OnPoped();
            selfReturnCoroutine = StartCoroutine(ReturnSelf());
        }

        public override void OnReturned()
        {
            base.OnReturned();
            if(null != selfReturnCoroutine)
                StopCoroutine(selfReturnCoroutine);
        }
        IEnumerator ReturnSelf()
        {
            yield return new WaitForSeconds(selfReturnTime);

            ObjectPool.Instance.ReturnOne(key, this);
        }
    }
}