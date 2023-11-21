using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyVampireSurvior.Editor
{
    [CustomEditor(typeof(PlayerItemInventory))]
    public class PlayerInventoryInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            using (var verticalSocpe = new EditorGUILayout.VerticalScope()) 
            {
                foreach (var item in (target as PlayerItemInventory).ItemCountByType)
                {
                    using (var horizontalScope = new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField(item.Key.ToString());
                        EditorGUILayout.LabelField(item.Value.ToString());
                    }
            }
            }
        }
    }

}