using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib.ObjectPool
{
    /// <summary>
    /// Ǯ ������Ʈ�� �⺻ Ŭ����
    /// </summary>
    /// <typeparam name="KeyT"></typeparam>
    [Serializable]
    public class PoolObject<KeyT> : MonoBehaviour
    {
        /// <summary>
        /// Ǯ���� ������ ������Ʈ�� Ű
        /// </summary>
        public KeyT key;
        /// <summary>
        /// Ǯ���� ���� �� �� ����
        /// </summary>
        public virtual void OnPoped() { }
        /// <summary>
        /// Ǯ�� �ٽ� �� �� �� ����
        /// </summary>
        public virtual void OnReturned() { }
    }
}
