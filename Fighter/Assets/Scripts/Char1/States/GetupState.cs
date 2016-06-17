using UnityEngine;
using System.Collections;

/*
 * this class represents the getup after the character has fallen to the ground.
 * this state will make the character go from his lying down state into the idle state.
 */

public class GetupState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 14);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Getup"))
        {
            stateMachine.SetState(StateID.Idle);
        }

    }

    public override void Leave()
    {
    }
}
