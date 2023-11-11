using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyVampireSurvior
{
    public class QuickslotController : MonoBehaviour
    {
        [SerializeField] Image iconImage;
        public void SetImage(Sprite sprite)
        {
            iconImage.sprite = sprite;
        }
    }
}