using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MyVampireSurvior
{
    public class LocationSelectionIndicator : MonoBehaviour
    {
        [SerializeField]
        SkillData skillData;

        public void SetSkillDate(SkillData skillData)
        {
            this.skillData = skillData;
            switch (skillData.skillType)
            {
                case SkillType.InstantAoE:
                case SkillType.DotAoE:
                    var convertedSkill = skillData as AoESkillData;
                    if (null == convertedSkill)
                        throw new InvalidOperationException("skill data is not AoESkill");

                    switch (convertedSkill.shape)
                    {
                        case AoESkillShape.Circle:
                            transform.localScale = new Vector3(convertedSkill.size.x, convertedSkill.size.x, convertedSkill.size.x);
                            break;
                        case AoESkillShape.Rectangle:
                            transform.localScale = new Vector3(convertedSkill.size.x, convertedSkill.size.y, 0);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    throw new InvalidOperationException($"{skillData.skillType} Not supported yet");
            }
        }

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