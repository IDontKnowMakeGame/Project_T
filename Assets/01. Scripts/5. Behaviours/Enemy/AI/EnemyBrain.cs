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
            ChangeState(states[0]);
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
                    ChangeState(transition.to);
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