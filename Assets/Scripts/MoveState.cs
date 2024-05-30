using UnityEngine;
namespace DefaultNamespace
{
    public class MoveState : State
    {
        private readonly float _moveSpeed;
        private readonly float _rotationSpeed;
        private readonly Transform _targetTransform;
        
        public MoveState(FSM fsm, float moveSpeed, float rotationSpeed, Transform transform) : base(fsm)
        {
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
            _targetTransform = transform;

            Type = StateType.Move;
        }

        public override void Update()
        {
            _targetTransform.Translate(_targetTransform.forward * (_moveSpeed * Time.deltaTime), Space.World);
            _targetTransform.Rotate(Vector3.up * (_rotationSpeed * Time.deltaTime), Space.Self);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Fsm.SetState(StateType.Idle);
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fsm.SetState(StateType.Scale);
            }
        }
    }
}
