       using System;
using System.Collections.Generic;
using Scripts.Behaviours.Enemy.AI.Base;
using Scripts.Utilities.Data;
using UnityEngine;

namespace Scripts.Behaviours.Enemy.AI
{
    public class EnemyBrain : Behaviour
    {
        public State CurrentState { get; set; }

        public AiFsm fsm;

        private void Start()
        {
            ChangeState(fsm.states[0]);
        }
        
        public State GetState(string stateName)
        {
            return fsm.GetState(stateName);
        }

        private void Update()
        {
            if (CurrentState == null)
            {
                return;
            }

            CurrentState.onUpdate?.Invoke();

            foreach (var transition in CurrentState.transitions)
            {
                var result = transition.conditions.Check();
                // Debug.Log(result);
                if (result)
                {
                    var next = GetState(transition.to);
                    ChangeState(next);
                    break;
                }
            }
        }

        public void ChangeState(State state)
        {
            if(CurrentState != null)
                CurrentState.onExit?.Invoke();
            CurrentState = state;
            CurrentState.onEnter?.Invoke();
        }
    }
}