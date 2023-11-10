using JLib.ObjectPool;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyVampireSurvior
{

    public class HpSliderManager : MonoBehaviour
    {
        [SerializeField] PoolKey sliderKey;
        [SerializeField] Canvas canvas;

        Dictionary<IHpGettable, HpSlider> hpSliderByGetter = new Dictionary<IHpGettable, HpSlider>(1024);

        public void AddOne(IHpGettable hpGetterble)
        {
            var one = ObjectPool.Instance.PopOne(PoolKey.HPSlider);
            one.transform.SetParent(canvas.transform);

            var hpSlider = one.GetComponent<HpSlider>();
            hpSlider.HpGetter = hpGetterble;
            hpSlider.ParentCanvas = canvas; 

            hpSliderByGetter[hpGetterble] = hpSlider;
        }

        public void RemoveOne(IHpGettable hpGetterble)
        {
            HpSlider found = null;
            if(false == hpSliderByGetter.TryGetValue(hpGetterble, out found))
            {
                throw new InvalidOperationException($"there is no hp slider key : {(hpGetterble as Component).name}");
            }

            //굳이 필요할까?
            found.transform.SetParent(null);
            found.ParentCanvas = null;

            ObjectPool.Instance.ReturnOne(sliderKey, found);

            hpSliderByGetter.Remove(hpGetterble);
        }        
    }
}