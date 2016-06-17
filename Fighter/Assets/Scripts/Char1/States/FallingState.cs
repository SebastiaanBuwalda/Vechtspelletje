using UnityEngine;
using System.Collections;

/*
 * this class represents the falling state. the character enters this state when hit out of the air or when hit by a heavy attack while in hitstun.
 * when the character hits the ground in this state he enters the hard landing state
 */

public class FallingState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;
    private bool onGround;
    [SerializeField]
    private Rigidbody rb;

    private bool inState;

    public override void Enter()
    {
        inState = true;
        anim.SetInteger("AnimState", 11);
        Physics.gravity = new Vector3(0, -30, 0);
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == GameTags.floor && inState == true)
        {
            
            stateMachine.SetState(StateID.HardLanding);
        }
        
    }

    public override void Act()
    {

    }

    public override void Reason()
    {
    }

    public override void Leave()
    {
        inState = false;
        Physics.gravity = new Vector3(0, -25, 0);
    }

}
