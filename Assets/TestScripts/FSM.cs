using System;
using System.Collections.Generic;
namespace TestScripts
{
    public enum StateType
    {
        Circle,
        Idle,
        Scale
    }
    
    public class FSM
    {
        public State CurrentState { get; private set; }

        private Dictionary<StateType, State> _states = new();

        public void AddState(State state)
        {
            _states.Add(state.StateType, state);
        }

        public void SetState(StateType type)
        {
            
            if(CurrentState?.StateType == type) return;

            if (_states.TryGetValue(type, out var newState))
            {
                CurrentState?.Exit();

                CurrentState = newState;
                
                CurrentState.Enter();
            }
        }

        public void UpdateState()
        {
            CurrentState.Update();
        }
    }
}
