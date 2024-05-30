namespace BehaviourTree.Scripts.Test
{
    public abstract class BTNode
    {
        public enum NodeState { RUNNING, SUCCESS, FAILURE }

        protected NodeState state;

        public abstract NodeState Evaluate();
    }
}
