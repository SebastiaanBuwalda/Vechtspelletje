using UnityEngine;
using System.Collections;

/*
 * this class represents the standing block state.
 * this state is entered from the standing parry state is functions similarly to the crouch variant.
 */

public class BlockStandingState1 : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;
    private bool inState;

    public override void Enter()
    {
        inState = true;
        anim.SetInteger("AnimState", 19);
    }

    public override void Act()
    {

    }

    public override void Reason()
    {
        ReadInputs();
    }

    public override void Leave()
    {
        inState = false;
    }

    void ReadInputs()
    {
        if(!Input.GetKey(KeyCode.R))
        {
            //leave blocking state, go to Idle
            stateMachine.SetState(StateID.Idle);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(inState)
        {
            if(coll.tag != GameTags.heavyCrouchHitbox || coll.tag != GameTags.lightCrouchHitbox)
            {
                //successfully block the attack
            }
            else
            {
                //go to hitstun state, attack bypassed block because it was too low
                //i thought it might be fun to bring the player into the falling state if he gets hit by the heavy crouch attack while blocking
            }
        }
    }
}
