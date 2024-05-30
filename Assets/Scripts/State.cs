namespace DefaultNamespace
{
    public enum StateType
    {
        Idle,
        Move,
        Scale
    }
    
    public abstract class State
    {
        protected FSM Fsm;
        public StateType Type { get; protected set; }

        public State(FSM fsm)
        {
            Fsm = fsm;
        }
        
        public virtual void Enter()  {}
        public virtual void Update() {}
        public virtual void Exit() {}
    }
}
