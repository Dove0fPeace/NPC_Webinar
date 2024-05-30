namespace BehaviourTree.Scripts.Test
{
    public class Sequence : BTNode
    {
        private BTNode[] _nodes;
        private int _currentNodeIndex = 0;

        public Sequence(BTNode[] nodes)
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
                    case NodeState.FAILURE:
                        _currentNodeIndex = 0;
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                }
            }
            _currentNodeIndex = 0;
            state = NodeState.SUCCESS;
            return state;
        }
    }
}
