using System;
using System.Collections.Generic;
using Scripts.Behaviours.Enemy.AI.Base;

namespace Scripts.Behaviours.Enemy.AI
{
    public class EnemyBrain : Behaviour
    {
        public State CurrentState { get; set; }

        public List<State> states = new();

        public State GetState(string name)
        {
            return states.Find(state => state.stateName == name);
        }

        private void Start()
        {
            CurrentState = states[0];
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
                if (transition.conditions.Check())
                {
                    CurrentState.onExit?.Invoke();
                    CurrentState = transition.to;
                    CurrentState.onEnter?.Invoke();
                    break;
                }
            }
        }
    }
}