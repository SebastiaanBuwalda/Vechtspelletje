using UnityEngine;
using System.Collections;

/*
 * this class represents the jump forward state.
 * it is the same as the regular jump state exept that you jump forward instead of straight up.
 */

public class JumpForwardState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Vector3 jumpVector;

    void Start()
    {
        Physics.gravity = new Vector3(0, -25, 0);
    }

    public override void Enter()
    {
        rb.AddForce(jumpVector, ForceMode.Impulse);
    }

    public override void Act()
    {

    }

    public override void Reason()
    {

    }

    public override void Leave()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            stateMachine.SetState(StateID.Idle);
        }
    }
}
