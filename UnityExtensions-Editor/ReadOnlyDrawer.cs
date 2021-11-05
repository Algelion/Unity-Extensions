using UnityEngine;

namespace UnityEditor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public sealed class ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            using (var scope = new EditorGUI.DisabledGroupScope(true))
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
        }
    }

    [CustomPropertyDrawer(typeof(BeginReadOnlyGroupAttribute))]
    public sealed class BeginReadOnlyGroupDrawer : DecoratorDrawer
    {
        public override float GetHeight() { return 0; }

        public override void OnGUI(Rect position)
        {
            EditorGUI.BeginDisabledGroup(true);
        }
    }

    [CustomPropertyDrawer(typeof(EndReadOnlyGroupAttribute))]
    public sealed class EndReadOnlyGroupDrawer : DecoratorDrawer
    {
        public override float GetHeight() { return 0; }

        public override void OnGUI(Rect position)
        {
            EditorGUI.EndDisabledGroup();
        }
    }
}
