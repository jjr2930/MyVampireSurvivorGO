using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyVampireSurvior
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonController : MonoBehaviour
    {
        [SerializeField]
        Button button;

        protected virtual void Reset()
        {
            button = GetComponent<Button>();
        }

        protected virtual void Awake()
        {
            button.onClick.AddListener(OnClikced);
        }

        public abstract void OnClikced();
    } 
}
