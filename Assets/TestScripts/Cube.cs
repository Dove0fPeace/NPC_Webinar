using UnityEngine;
namespace TestScripts
{
    [RequireComponent(typeof(Renderer))]
    public class Cube : MonoBehaviour
    {
        [Header("Idle")]
        [SerializeField] private Material idleMaterial;
        
        [Header("Circle")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        [Header("Scale")]
        [SerializeField] private float maxScale;
        [SerializeField] private float scaleSpeed;

        private FSM _fsm;

        private void Start()
        {
            _fsm = new FSM();
            
            _fsm.AddState(new CircleState(_fsm, moveSpeed, rotationSpeed, transform));
            _fsm.AddState(new IdleState(_fsm, idleMaterial, GetComponent<Renderer>()));
            _fsm.AddState(new ScaleState(_fsm, maxScale, scaleSpeed, transform ));
            
            _fsm.SetState(StateType.Circle);
        }

        private void Update()
        {
            _fsm.UpdateState();
        }
    }
}
