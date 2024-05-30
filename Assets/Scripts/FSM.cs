using System.Collections.Generic;
namespace DefaultNamespace
{
    public class FSM
    {
        private State _currentState;
        private readonly Dictionary<StateType, State> _states = new();

        public void AddState(State state)
        {
            _states.TryAdd(state.Type, state);
        }

        public void SetState(StateType stateType)
        {
            if(_currentState?.Type == stateType) return;

            if (_states.TryGetValue(stateType, out var newState))
            {
                _currentState?.Exit();
                _currentState = newState;
                _currentState.Enter();
            }
        }

        public void UpdateState()
        {
            _currentState.Update();
        }
    }
}
