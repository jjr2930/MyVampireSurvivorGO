using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JLib.FSM;

namespace MyVampireSurvior
{
    public class ReadyState : State
    {
        [SerializeField] float delayTime = 0;
        [SerializeField] float endTime = 0;
        [SerializeField] EnemySpawner enemySpawnerPrefab = null;

        EnemySpawner spawner = null;
        public override void OnEntered(StateMachineRunner owner)
        {
            base.OnEntered(owner);
            endTime = Time.time + delayTime;

            spawner = Instantiate(enemySpawnerPrefab);
        }

        public override void OnUpdate(StateMachineRunner owner)
        {
            base.OnUpdate(owner);
            Debug.Log((int)(endTime - Time.time));
            if (Time.time >= endTime) 
            {
                owner.PushEvent("ReadyFinished");
                spawner.StartSpawn();
            }
        }
    }
}