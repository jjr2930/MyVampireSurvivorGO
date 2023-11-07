using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib.ObjectPool
{
    /// <summary>
    /// JLib.ObjectPool.DefaultObjectPool,
    /// JLib.ObjectPoo.Addressable.DefaultObjectPool
    /// ���� ����� ������ƮǮ�� ������Ʈ ���� �ΰ��� Ŭ������ DefaultPoolObjectŬ������ ����Ѵ�.
    /// </summary>

    public class DefaultPoolObject : PoolObject<DefaultKey>
    {
        public override void OnPoped()
        {
            base.OnPoped();
            gameObject.SetActive(true);
        }

        public override void OnReturned()
        {
            base.OnReturned();
            gameObject.SetActive(false);
        }
    }
}
