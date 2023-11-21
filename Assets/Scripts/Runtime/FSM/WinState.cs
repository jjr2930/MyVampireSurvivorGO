using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JLib.FSM;

namespace MyVampireSurvior
{

    public class WinState : State
    {
        public override void OnEntered(StateMachineRunner owner)
        {
            base.OnEntered(owner);
            Debug.Log("YOU WIN");
        }
    }
}