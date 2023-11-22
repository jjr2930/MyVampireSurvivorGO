using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JLib.FSM;
using System;

namespace MyVampireSurvior
{
    public class IngameManager : MonoBehaviour
    {
        [SerializeField]
        StateMachineRunner fsmRunner;

        private void Awake()
        {
            EventContainer.onSlotButtonClicked += OnSlotButtonClicked;
            EventContainer.onSkillLocationSelected += OnSkillLocationSelected;
        }

        private void OnDestroy()
        {
            EventContainer.onSlotButtonClicked -= OnSlotButtonClicked;
            EventContainer.onSkillLocationSelected -= OnSkillLocationSelected;
        }

        private void OnSkillLocationSelected(SkillData skillData, Vector3 worldPosition)
        {
            switch (skillData.skillType)
            {
                case SkillType.InstantAoE:
                    fsmRunner.PushEvent("LocationSelectionFinished");
                    break;

                default:
                    throw new NotImplementedException($"{skillData.skillType} is not supported");
            }
        }

        private void OnSlotButtonClicked(SkillData clickedSkill)
        {
            switch (clickedSkill.skillType)
            {
                case SkillType.InstantAoE:
                case SkillType.DotAoE:
                    fsmRunner.SetBlackboardValue("SelectedSkill", clickedSkill as UnityEngine.Object);
                    fsmRunner.PushEvent("LocationSelectionStart");
                    break;

                case SkillType.Instant:
                case SkillType.Dot:
                    fsmRunner.SetBlackboardValue("SelectedSkill", clickedSkill as UnityEngine.Object);
                    fsmRunner.PushEvent("TargetSelectionStart");
                    break;
                default:
                    break;
            }
        }
    }
}