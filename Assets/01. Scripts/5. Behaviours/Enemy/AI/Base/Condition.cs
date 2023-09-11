using System;
using System.Collections.Generic;
using Scripts.Utilities.Core;
using UnityEngine;

namespace Scripts.Behaviours.Enemy.AI.Base
{
    public enum ECondition
    {
        None,
        Time,
        Distance,
        Health,
        Box,
        Area,
    }
    
    [CreateAssetMenu(fileName = "Condition", menuName = "AI/Condition")]
    public class Condition : ScriptableObject
    {
        public bool isNegated;
        public bool isImportant;

        public int intVal = 0;
        public float floatVal = 0f;
        
        public ECondition condition = ECondition.None;

        public virtual bool Check()
        {
            return Define.Conditions[condition].Invoke();
        }

        
    }
}