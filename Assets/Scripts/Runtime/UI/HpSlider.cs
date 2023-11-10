using JLib.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace MyVampireSurvior
{

    public class HpSlider : PoolObject
    {
        [SerializeField] Slider slider;
        [SerializeField] Vector2 delta;

        public IHpGettable HpGetter { get; set; }
        public Canvas ParentCanvas { get; set; }

        public void Update()
        {
            if(null == HpGetter)
            {
                Debug.Log("HP getter is null");
                return;
            }

            slider.value = HpGetter.GetCurrentHpRate();

            var com = (HpGetter as Component);
            var screenPosition = Camera.main.WorldToScreenPoint(com.transform.position);
            Vector2 localPosition;
            if (false == RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform, screenPosition, ParentCanvas.worldCamera, out localPosition))
            {
                Debug.Log("calcualte screen point to parent rectangle");
                return;
            }

            slider.transform.localPosition = localPosition + delta;
        }
    }
}