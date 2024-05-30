using SpaceShooter;
using UnityEngine;
using UnityEngine.AI;
namespace BehaviourTree.Scripts.Test
{
    public class Attack : BTNode
    {
        private NavMeshAgent _agent;
        private NPCBehaviorTree _behaviorTree;
        private CheckAttackCooldown _checkAttackCooldown;
        private Transform _lastTarget;
        private bool _isAttacking;
        private float _attackCounter;
        private float _attackTime;
        private int _damage;

        public Attack(NavMeshAgent agent, NPCBehaviorTree behaviorTree, CheckAttackCooldown checkAttackCooldown, float attackTime, int damage)
        {
            _agent = agent;
            _behaviorTree = behaviorTree;
            _checkAttackCooldown = checkAttackCooldown;
            _attackTime = attackTime;
            _damage = damage;
            _isAttacking = false;
            _attackCounter = 0f;
        }

        public override NodeState Evaluate()
        {
            Transform target = _behaviorTree.GetTargetTransform();

            if (target == null)
            {
                state = NodeState.FAILURE;
                return state;
            }

            if (!_checkAttackCooldown.IsCooldownOver())
            {
                state = NodeState.FAILURE;
                return state;
            }

            if (!_isAttacking)
            {
                StartAttack(target);
                state = NodeState.RUNNING;
                return state;
            }

            _attackCounter += Time.deltaTime;
            if (_attackCounter >= _attackTime)
            {
                ExecuteAttack();
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.RUNNING;
            return state;
        }

        private void StartAttack(Transform target)
        {
            _agent.isStopped = true;
            _isAttacking = true;
            _attackCounter = 0f;
            _lastTarget = target;
        }

        private void ExecuteAttack()
        {
            Destructible destructible = _lastTarget.GetComponent<Destructible>();
            if (destructible != null)
            {
                destructible.ApplyDamage(_damage, true);
                if (destructible.CurrentHP <= 0)
                {
                    _behaviorTree.SetTarget(null);
                }
            }

            _checkAttackCooldown.ResetCooldown();
            _agent.isStopped = false;
            _isAttacking = false;
        }
    }
}
