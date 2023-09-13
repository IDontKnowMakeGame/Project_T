using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Behaviours.Enemy.AI.Base
{
    [Serializable]
    public class Transition
    { 
        public string to = null;
        
        public Conditions conditions = null;
    }
}