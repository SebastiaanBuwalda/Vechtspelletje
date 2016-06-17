using UnityEngine;
using System.Collections;

/* 
 * this class represents the action that happens when the player hits the ground after having entered the falling state. (a little body bounce opon hitting the ground).
 * From this state the character enters the lying down state when the animation is finished.
 */

public class HardLandingState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 13);
    }

    public override void Act()
    {
        
    }

    public override void Reason()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Hard Landing"))
        {
            stateMachine.SetState(StateID.Getup);
        }
    }

    public override void Leave()
    {
        
    }
}
