using UnityEngine;
using UnityEngine.AI;
namespace BehaviourTree.Scripts.Test
{
    public class NPCBehaviorTree : MonoBehaviour
    {
        [SerializeField] private Transform[] patrolPoints;
        [SerializeField] private float detectRange = 10f;
        [SerializeField] private float attackRange = 2f;
        [SerializeField] private float attackCooldown = 2f;
        [SerializeField] private float attackTime = 1f;
        [SerializeField] private int damage = 10;

        private BTNode _rootNode;
        private NavMeshAgent _agent;
        private Transform _target;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();

            // Создаем узлы дерева поведения
            var patrol = new Patrol(_agent, patrolPoints);
            var checkDestructibleInDetectRange = new CheckDestructibleInRange(transform, detectRange, SetTarget);
            var checkDestructibleInAttackRange = new CheckDestructibleInRange(transform, attackRange, null);
            var checkAttackCooldown = new CheckAttackCooldown(attackCooldown);
            var chase = new Chase(_agent, this, attackRange);
            var attack = new Attack(_agent, this, checkAttackCooldown, attackTime, damage);

            // Создаем последовательность атаки
            var attackSequence = new Sequence(new BTNode[]
            {
                checkDestructibleInAttackRange,
                checkAttackCooldown,
                attack
            });

            // Создаем последовательность боя
            var combatSequence = new Selector(new BTNode[]
            {
                attackSequence,
                new Sequence(new BTNode[]
                {
                    checkDestructibleInDetectRange,
                    new Selector(new BTNode[]
                    {
                        checkDestructibleInAttackRange,
                        chase
                    })
                })
            });

            // Корневой селектор, который включает патрулирование и боевую последовательность
            _rootNode = new Selector(new BTNode[]
            {
                combatSequence,
                patrol
            });
        }

        private void Update()
        {
            _rootNode.Evaluate();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, detectRange);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }

        public void SetTarget(Transform newTarget)
        {
            _target = newTarget;
        }

        public Transform GetTargetTransform()
        {
            return _target;
        }
    }
}
