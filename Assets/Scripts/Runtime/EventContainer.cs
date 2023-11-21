using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{
    public static class EventContainer 
    {
        public delegate void OnSkillLocationSelectedDelegate(SkillData skillData, Vector3 worldPosition);

        public static Action<SkillData> onSlotButtonClicked;
        public static OnSkillLocationSelectedDelegate onSkillLocationSelected;
    }
}