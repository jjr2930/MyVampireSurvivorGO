using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JLib.FSM;
using UnityEngine.AddressableAssets;

namespace MyVampireSurvior
{
    public class LocationSelectionState : State
    {
        [SerializeField] float orthographSize = 10f;
        [SerializeField] float originSize;
        [SerializeField] AssetReferenceT<LocationSelectionIndicator> indicatorPrefab;
        LocationSelectionIndicator indicator;

        public override void OnEntered(StateMachineRunner owner)
        {
            base.OnEntered(owner);
            
            Time.timeScale = 0f;

            originSize = Camera.main.orthographicSize;
            Camera.main.orthographicSize += orthographSize;

            var indicatorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            indicatorPosition.z = -1f;
            if (null == indicatorPrefab)
            { indicatorPrefab.InstantiateAsync(indicatorPosition, Quaternion.identity).Completed +=
                (handler) =>
                {
                    indicator.
                };
            }
            else
            {
                indicator
            }
        }



        public override void OnExit(StateMachineRunner owner)
        {
            base.OnExit(owner);
            Time.timeScale = 1f;
            Camera.main.orthographicSize -= originSize;
        }
    }
}