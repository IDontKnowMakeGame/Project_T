using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Behaviours.Enemy.AI.Base
{
    //[CreateAssetMenu(fileName = "State", menuName = "AI/State")]
    [Serializable]
    public class State
    {
        public string stateName = null;
        
        public Transition[] transitions = Array.Empty<Transition>();
        
        public Action onEnter = null;
        public Action onUpdate = null;
        public Action onExit = null;
    }
}