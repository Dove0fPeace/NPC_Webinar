namespace BehaviourTree.Scripts.Test
{
    public class Selector : BTNode
    {
        private BTNode[] _nodes;
        private int _currentNodeIndex = 0;

        public Selector(BTNode[] nodes)
        {
            _nodes = nodes;
        }

        public override NodeState Evaluate()
        {
            for (int i = _currentNodeIndex; i < _nodes.Length; i++)
            {
                switch (_nodes[i].Evaluate())
                {
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    case NodeState.SUCCESS:
                        _currentNodeIndex = 0;
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.FAILURE:
                        continue;
                }
            }
            _currentNodeIndex = 0;
            state = NodeState.FAILURE;
            return state;
        }
    }
}
