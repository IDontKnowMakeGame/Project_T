using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    
    //[CreateAssetMenu(fileName = "Condition", menuName = "AI/Condition")]
    [Serializable]
    public class Condition
    {
        public bool isNegated;
        public bool isImportant = false;
        
        public InputData value = new();
        
        public ECondition condition = ECondition.None;

        public virtual bool Check()
        {
            return Define.Conditions[condition].Invoke(value);
        }
    }

    [Serializable]
    public class InputData
    {
        public int intVal;
        public float floatVal;
    }
    
}