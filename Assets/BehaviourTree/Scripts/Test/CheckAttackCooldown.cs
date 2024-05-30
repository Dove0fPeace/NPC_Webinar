using UnityEngine;
namespace BehaviourTree.Scripts.Test
{
    public class CheckAttackCooldown : BTNode
    {
        private float _lastAttackTime;
        private float _cooldownDuration;

        public CheckAttackCooldown(float cooldownDuration)
        {
            _cooldownDuration = cooldownDuration;
        }

        public bool IsCooldownOver()
        {
            return Time.time - _lastAttackTime >= _cooldownDuration;
        }

        public void ResetCooldown()
        {
            _lastAttackTime = Time.time;
        }

        public override NodeState Evaluate()
        {
            return IsCooldownOver() ? NodeState.SUCCESS : NodeState.FAILURE;
        }
    }
}
