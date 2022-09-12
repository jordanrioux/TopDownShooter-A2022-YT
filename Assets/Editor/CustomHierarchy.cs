using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TopDownShooter.Editor
{
    [InitializeOnLoad]
    public static class CustomHierarchy
    {
        private static readonly Vector2 Offset = new Vector2(0, 2);
        
        static CustomHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= HandleHierarchyWindowItemOnGUI;
            EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        }

        private static void HandleHierarchyWindowItemOnGUI(int instanceId, Rect selectionRect)
        {
            var textColor = Color.yellow;
            var backgroundColor = new Color(0.278431f, 0.278431f, 0.278431f);

            var obj = EditorUtility.InstanceIDToObject(instanceId);
            if (obj != null)
            {
                if (Selection.instanceIDs.Contains(instanceId))
                {
                    textColor = Color.white;
                    backgroundColor = new Color(0.24f, 0.48f, 0.90f);
                }

                var prefabType = PrefabUtility.GetPrefabAssetType(obj);
                var gameObject = obj as GameObject;
                if (gameObject != null && gameObject.CompareTag("EditorOnly"))
                {
                    var offsetRect = new Rect(selectionRect.position + Offset, selectionRect.size);
                    EditorGUI.DrawRect(selectionRect, backgroundColor);
                    EditorGUI.LabelField(offsetRect, obj.name, new GUIStyle()
                    {
                        normal = new GUIStyleState() { textColor = textColor },
                        fontStyle = FontStyle.Bold
                    });
                }
            }
        }
    }
}
