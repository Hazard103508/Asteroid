using UnityEditor;
using UnityEngine;

namespace UnityShared.Structs.Editor
{
    [CustomPropertyDrawer(typeof(RangeNumber<float>))]
    [CustomPropertyDrawer(typeof(RangeNumber<int>))]
    public class RangeNumberEditor : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't indent child fields
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            var lblminRec = new Rect(position.x, position.y, 30, position.height);
            var minRec = new Rect(position.x + 30, position.y, 30, position.height);
            var lblmaxRec = new Rect(position.x + 70, position.y, 30, position.height);
            var maxRec = new Rect(position.x + 100, position.y, 30, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.LabelField(lblminRec, "Min");
            EditorGUI.PropertyField(minRec, property.FindPropertyRelative("min"), GUIContent.none);
            EditorGUI.LabelField(lblmaxRec, "Max");
            EditorGUI.PropertyField(maxRec, property.FindPropertyRelative("max"), GUIContent.none);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}
