namespace TestScripts
{
    public abstract class State
    {
        protected readonly FSM Fsm;
        public StateType StateType { get; protected set; }

        public State(FSM fsm)
        {
            Fsm = fsm;
        }
        
        public virtual void Enter() {}
        public virtual void Update() {}
        public virtual void Exit() {}
    }
}
