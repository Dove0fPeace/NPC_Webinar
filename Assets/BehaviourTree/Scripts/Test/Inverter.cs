namespace BehaviourTree.Scripts.Test
{
    public class Inverter : BTNode
    {
        private BTNode node;

        public Inverter(BTNode node)
        {
            this.node = node;
        }

        public override NodeState Evaluate()
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    state = NodeState.RUNNING;
                    break;
                case NodeState.SUCCESS:
                    state = NodeState.FAILURE;
                    break;
                case NodeState.FAILURE:
                    state = NodeState.SUCCESS;
                    break;
            }
            return state;
        }
    }
}

