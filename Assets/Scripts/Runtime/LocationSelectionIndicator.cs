using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    public class LocationSelectionIndicator : MonoBehaviour
    {
        [SerializeField]
        SkillData skillData;

        void Update()
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPosition.z = -1;
            transform.position = worldPosition;

            if(Input.GetButtonDown("Fire1"))
            {
                EventContainer.onSkillLocationSelected?.Invoke(skillData, transform.position);
            }
        }
    }
}