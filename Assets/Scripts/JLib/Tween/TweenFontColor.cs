﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using TMPro;

namespace JLib.Tween
{
    [AddComponentMenu("JTween/TweenFontColor")]
    public class TweenFontColor : Tween<Color>
    {
        TextMeshProUGUI txt = null;

        // Use this for initialization
        protected override void OnAwake()
        {
            txt = GetComponent<TextMeshProUGUI>();
        }

        protected override void OnOnEnable()
        {
            txt.color = realFrom;
        }

        protected override void OnTweenUpdate()
        {
            txt.color = Lerp();
        }

        public override Color Lerp()
        {
            return Color.Lerp( realFrom , realTo , curveValue );
        }
    }
}