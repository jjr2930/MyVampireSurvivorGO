using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyVampireSurvior
{
    public class QuickSlotButton : ButtonController
    {
        [SerializeField]
        Image icon;

        [SerializeField]
        SkillData skillData;

        protected override void Awake()
        {
            base.Awake();

            var skillInventory = FindObjectOfType<PlayerSkillInventory>();
            skillData = skillInventory[transform.GetSiblingIndex()];

            AddressablesHelper.LoadAsync<Sprite>(skillData.icon).Completed +=
                (handler) =>
                {
                    icon.sprite = handler.Result;
                };
        } 

        public override void OnClikced()
        {
            EventContainer.onSlotButtonClicked?.Invoke(skillData);
        }
    }
}