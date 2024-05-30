using System;
using UnityEngine;
namespace DefaultNamespace
{
    [RequireComponent(typeof(Renderer))]
    public class Cube : MonoBehaviour
    {
        [SerializeField] private StateType startState;
        
        [Header("Move")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        [Header("Idle")]
        [SerializeField] private Material idleMaterial;

        [Header("Scale")]
        [SerializeField] private float maxScale;
        [SerializeField] private float scaleSpeed;

        private FSM _fsm;

        private void Start()
        {
            _fsm = new FSM();
            
            _fsm.AddState(new MoveState(_fsm, moveSpeed, rotationSpeed, transform));
            _fsm.AddState(new IdleState(_fsm, idleMaterial, GetComponent<Renderer>()));
            _fsm.AddState(new ScaleState(_fsm, maxScale, scaleSpeed, transform));
            
            _fsm.SetState(startState);
        }

        private void Update()
        {
            _fsm.UpdateState();
        }
    }
}
