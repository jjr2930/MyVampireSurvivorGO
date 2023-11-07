using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    public class FieldItem : MonoBehaviour
    {
        [SerializeField]
        ItemType type;

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
        }
    }
}