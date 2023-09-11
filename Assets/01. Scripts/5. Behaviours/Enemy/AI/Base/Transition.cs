using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Behaviours.Enemy.AI.Base
{
    [Serializable]
    public class Transition
    { 
        public State to = null;
        
        public Conditions conditions = null;
    }
}