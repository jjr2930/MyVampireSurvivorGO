using JLib.ObjectPool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool = JLib.ObjectPool.Addressables.DefaultObjectPoolWithAddressables;

namespace MyVampireSurvior
{
    public class FieldItem : DefaultPoolObject
    {
        [SerializeField]
        ItemType type;

        public ItemType ItemType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;   
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var playerInput = collision.GetComponent<PlayerInput>();
            var isPlayer = null != playerInput;
            if (false == isPlayer)
                return;

            var playerInventory = playerInput.GetComponent<PlayerInventory>();
            if (null == playerInventory)
                throw new InvalidOperationException("there is no playerInventory , " + playerInput.name);

            playerInventory.AddItem(type);

            ObjectPool.Instance.ReturnOne(this.key, this);
        }
    }
}