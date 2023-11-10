using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace MyVampireSurvior
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] PlayerStatData data;
        [SerializeField] ProjectileSpawner bulletSpawner;

        // Update is called once per frame
        void Update()
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            {
                direction += transform.up;
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            {
                direction -= transform.up;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A))
            {
                direction -= transform.right;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D))
            {
                direction += transform.right;
            }

            direction.Normalize();
            transform.position += direction * data.moveSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                bulletSpawner.enabled = !bulletSpawner.enabled;
            }
        }
    }

}