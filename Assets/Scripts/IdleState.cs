using UnityEngine;
namespace DefaultNamespace
{
    public class IdleState : State
    {
        private Material _idleMaterial;
        private Material _savedMaterial;

        private Renderer _targetRenderer;
        
        public IdleState(FSM fsm, Material idleMaterial, Renderer targetRenderer) : base(fsm)
        {
            _idleMaterial = idleMaterial;
            _targetRenderer = targetRenderer;

            Type = StateType.Idle;
        }

        public override void Enter()
        {
            _savedMaterial = _targetRenderer.material;
            _targetRenderer.material = _idleMaterial;
        }

        public override void Update()
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Fsm.SetState(StateType.Move);
            }
        }

        public override void Exit()
        {
            _targetRenderer.material = _savedMaterial;
        }
    }
}
