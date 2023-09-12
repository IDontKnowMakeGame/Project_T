using System.Collections.Generic;
using Scripts.Behaviours.Enemy.AI.Base;
using UnityEngine;

namespace Scripts.Utilities.Data
{
    [CreateAssetMenu(fileName = "AiFsm", menuName = "AI/AiFsm")]
    public class AiFsm : ScriptableObject
    {
        public List<State> states = new();
        
        public State GetState(string stateName)
        {
            return states.Find(state => state.stateName == stateName);
        }
    }
}