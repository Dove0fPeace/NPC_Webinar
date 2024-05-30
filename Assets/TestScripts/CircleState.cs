using UnityEngine;
namespace TestScripts
{
    public class CircleState : State
    {
        private float _moveSpeed, _rotationSpeed;
        private Transform _targetTransform;
        
        public CircleState(FSM fsm, float moveSpeed, float rotationSpeed, Transform targetTransform) : base(fsm)
        {
            _moveSpeed = moveSpeed;
            _rotationSpeed = rotationSpeed;
            _targetTransform = targetTransform;

            StateType = StateType.Circle;
        }

        public override void Update()
        {
            _targetTransform.Translate(_targetTransform.forward * (Time.deltaTime * _moveSpeed), Space.World);
            _targetTransform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed), Space.Self);

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
