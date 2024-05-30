using System;
using UnityEngine;
namespace BehaviourTree.Scripts.Test
{
    public class CheckDestructibleInRange : BTNode
    {
        private Transform _npc;
        private float _range;
        private Action<Transform> _onDetect;

        public CheckDestructibleInRange(Transform npc, float range, Action<Transform> onDetect)
        {
            _npc = npc;
            _range = range;
            _onDetect = onDetect;
        }

        public override NodeState Evaluate()
        {
            Collider[] hits = Physics.OverlapSphere(_npc.position, _range, LayerMask.GetMask("Player"));
            if (hits.Length > 0)
            {
                _onDetect?.Invoke(hits[0].transform);
                return NodeState.SUCCESS;
            }
            return NodeState.FAILURE;
        }
    }
}
