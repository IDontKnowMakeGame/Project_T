using Scripts.Behaviours.Enemy.AI.Base;
using Scripts.Utilities.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Scripts.Utilities.Editor
{
    [CustomEditor(typeof(Condition))]
    public class ConditionEditor : UnityEditor.Editor
    {
        private Condition _condition;
        private void OnEnable()
        {
            _condition = (Condition)target;
        }

        public override void OnInspectorGUI()
        {
            _condition.isNegated = EditorGUILayout.Toggle("Is Negated", _condition.isNegated);
            _condition.isImportant = EditorGUILayout.Toggle("Is Important", _condition.isImportant);

            _condition.condition = (ECondition)EditorGUILayout.EnumPopup("Condition", _condition.condition);

            switch (_condition.condition)
            {
                case ECondition.Time:
                    _condition.floatVal = EditorGUILayout.FloatField("Time", (float) _condition.floatVal);
                    break;
                case ECondition.Distance:
                    _condition.intVal = EditorGUILayout.IntField("Distance", (int) _condition.intVal);
                    break;
            }

            EditorUtility.SetDirty(_condition);
        }
    }
}