using UnityEngine;
using System.Collections;

/*
 * this class represents the jump.
 * this state is entered while the jump button is pressed while in the idle or crouch state
 * from this state the character can enter the aerial versions of the light and heavy attacks as well as the falling state upon getting hit, 
 * and the idle state upon hitting the ground without using a move.
 */

public class JumpState : State1 {

    [SerializeField] private StateMachine1 stateMachine;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 jumpVector;

    private Vector3 maxJumpVel = new Vector3(0, 12.7f, 0);

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
        Debug.Log(rb.velocity);
    }

    public override void Reason()
    {
        //cap max jump velocity
        if(rb.velocity.y > 12.7f)
        {
            rb.velocity = maxJumpVel;
        }
    }

    public override void Leave()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Floor")
        {
            stateMachine.SetState(StateID.Idle);
        }
    }
}
