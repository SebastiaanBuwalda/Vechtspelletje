using UnityEngine;
using System.Collections;

/*
 * this class represents the jump forward state.
 * it is the same as the regular jump state exept that you jump backward instead of straight up.
 */

public class JumpBackwardState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Vector3 jumpVector;

    public override void Enter()
    {
        rb.AddForce(jumpVector, ForceMode.Impulse);
    }

    public override void Act()
    {

    }

    public override void Reason()
    {
        //clamp jump velocity
        if (rb.velocity.y > 12.7f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 12.7f, rb.velocity.z);
        }
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
