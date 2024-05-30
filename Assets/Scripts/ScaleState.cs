using DG.Tweening;
using UnityEngine;
namespace DefaultNamespace
{
    public class ScaleState : State
    {
        private float _maxScale;
        private float _scaleSpeed;

        private float _savedScale;
        private Transform _targetTransform;
        
        public ScaleState(FSM fsm, float maxScale, float scaleSpeed, Transform transform) : base(fsm)
        {
            _maxScale = maxScale;
            _scaleSpeed = scaleSpeed;
            _targetTransform = transform;

            Type = StateType.Scale;
        }

        public override void Enter()
        {
            _savedScale = _targetTransform.localScale.x;
            _targetTransform.DOScale(_maxScale, _scaleSpeed).SetLoops(-1, LoopType.Yoyo).SetSpeedBased(true).SetEase(Ease.InOutSine);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fsm.SetState(StateType.Move);
            }
        }

        public override void Exit()
        {
            _targetTransform.DOKill();
            _targetTransform.DOScale(_savedScale, _scaleSpeed).SetSpeedBased();
        }
    }
}
