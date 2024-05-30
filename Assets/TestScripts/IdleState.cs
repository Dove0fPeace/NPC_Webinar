using UnityEngine;
namespace TestScripts
{
    public class IdleState : State
    {
        private readonly Material _idleMaterial;
        private readonly Renderer _targetRenderer;
        
        private Material _previousMaterial;
        
        public IdleState(FSM fsm, Material idleMaterial, Renderer renderer) : base(fsm)
        {
            _targetRenderer = renderer;
            _idleMaterial = idleMaterial;

            StateType = StateType.Idle;
        }

        public override void Enter()
        {
            _previousMaterial = _targetRenderer.material;
            _targetRenderer.material = _idleMaterial;
        }

        public override void Exit()
        {
            _targetRenderer.material = _previousMaterial;
        }

        public override void Update()
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                Fsm.SetState(StateType.Circle);
            }
        }
    }
}
