using System.Collections;
using System.Collections.Generic;
using JLib.FSM;
using UnityEngine;

namespace MyVampireSurvior
{
    public class LoseState : State
    {
        public override void OnEntered(StateMachineRunner owner)
        {
            base.OnEntered(owner);
            Debug.Log("YOU LOSE");
        }
    }
}