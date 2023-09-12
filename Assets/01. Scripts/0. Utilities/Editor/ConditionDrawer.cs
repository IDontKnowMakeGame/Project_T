using Scripts.Behaviours.Enemy.AI.Base;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Scripts.Utilities.Editor
{
    [CustomPropertyDrawer(typeof(Condition))]
    public class ConditionDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.x += 50f;
            position.width -= 50f;
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            
            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            var negatedField = property.FindPropertyRelative("isNegated");
            negatedField.boolValue = EditorGUI.Toggle(position, "Negated", negatedField.boolValue);
            
            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            var importantField = property.FindPropertyRelative("isImportant");
            importantField.boolValue = EditorGUI.Toggle(position, "Important", importantField.boolValue);

            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            var conditionField = property.FindPropertyRelative("condition");
            conditionField.enumValueIndex = EditorGUI.Popup(position, "Condition", conditionField.intValue, conditionField.enumNames);
            
            var valueField = property.FindPropertyRelative("value");
            var intVal = valueField.FindPropertyRelative("intVal");
            var floatVal = valueField.FindPropertyRelative("floatVal");

            position.y += EditorGUIUtility.singleLineHeight;
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            
            
            switch ((ECondition) conditionField.intValue)
            {
                case ECondition.Time :
                    floatVal.floatValue = EditorGUI.FloatField(position, "Time", floatVal.floatValue);
                    break;
                case ECondition.Distance :
                    intVal.intValue = EditorGUI.IntField(position,"Distance", intVal.intValue);
                    break;
            }
            
            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
            EditorUtility.SetDirty(property.serializedObject.targetObject);
        }
    }
}