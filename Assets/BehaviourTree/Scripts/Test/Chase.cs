using UnityEngine;
using UnityEngine.AI;
namespace BehaviourTree.Scripts.Test
{
    public class Chase : BTNode
    {
        private NavMeshAgent _agent;
        private NPCBehaviorTree _behaviorTree;
        private float _attackRange;

        public Chase(NavMeshAgent agent, NPCBehaviorTree behaviorTree, float attackRange)
        {
            _agent = agent;
            _behaviorTree = behaviorTree;
            _attackRange = attackRange;
        }

        public override NodeState Evaluate()
        {
            Transform target = _behaviorTree.GetTargetTransform();
            if (target == null)
            {
                return NodeState.FAILURE;
            }

            Vector3 direction = (_agent.transform.position - target.position).normalized;
            Vector3 destination = target.position + direction * _attackRange;

            _agent.SetDestination(destination);
            return NodeState.RUNNING;
        }
    }
}
