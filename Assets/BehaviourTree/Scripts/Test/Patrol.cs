using UnityEngine;
using UnityEngine.AI;
namespace BehaviourTree.Scripts.Test
{
    public class Patrol : BTNode
    {
        private NavMeshAgent _agent;
        private Transform[] _waypoints;
        private int _currentWaypointIndex;

        public Patrol(NavMeshAgent agent, Transform[] waypoints)
        {
            _agent = agent;
            _waypoints = waypoints;
            _currentWaypointIndex = 0;
        }

        public override NodeState Evaluate()
        {
            if (_agent.remainingDistance < _agent.stoppingDistance)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _agent.SetDestination(_waypoints[_currentWaypointIndex].position);
            }
            return NodeState.RUNNING;
        }
    }
}
