// using System;
// using Scripts.Behaviours.Enemy.AI.Base;
// using Scripts.Utilities.Data;
// using UnityEditor;
// using UnityEditor.UIElements;
// using UnityEngine;
// using UnityEngine.Rendering;
// using UnityEngine.UIElements;
//
// namespace Scripts.Utilities.Editor
// {
//     [CustomEditor(typeof(Condition))]
//     public class ConditionEditor : UnityEditor.Editor
//     {
//         private Condition _condition;
//
//         private void Awake()
//         {
//             _condition = (Condition) target;
//         }
//
//         public override void OnInspectorGUI()
//         {
//             base.OnInspectorGUI();
//             switch (_condition.condition)
//             {
//                 case ECondition.Time :
//                     _condition.value.floatVal = EditorGUILayout.FloatField("Time", _condition.value.floatVal);
//                     break;
//                 case ECondition.Distance :
//                     _condition.value.intVal = EditorGUILayout.IntField("Distance", _condition.value.intVal);
//                     break;
//             }
//             EditorUtility.SetDirty(_condition);
//         }
//     }
// }