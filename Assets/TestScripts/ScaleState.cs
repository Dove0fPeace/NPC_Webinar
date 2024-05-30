using DG.Tweening;
using UnityEngine;
namespace TestScripts
{
    public class ScaleState : State
    {
        private float _startScale;
        private readonly float _finalScale;
        private readonly float _scaleSpeed;
        private readonly Transform _targetTransform;
        
        public ScaleState(FSM fsm, float scale, float scaleSpeed, Transform targetTransform) : base(fsm)
        {
            _finalScale = scale;
            _scaleSpeed = scaleSpeed;
            _targetTransform = targetTransform;
            
            StateType = StateType.Scale;
        }

        public override void Enter()
        {
            _startScale = _targetTransform.localScale.x;
            _targetTransform.DOScale(_finalScale, _scaleSpeed).SetLoops(-1, LoopType.Yoyo).SetSpeedBased(true).SetEase(Ease.InOutSine);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fsm.SetState(StateType.Circle);
            }
        }

        public override void Exit()
        {
            _targetTransform.DOKill();
            _targetTransform.DOScale(_startScale, _scaleSpeed).SetSpeedBased(true);
        }
    }
}
