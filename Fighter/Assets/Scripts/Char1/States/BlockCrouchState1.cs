using UnityEngine;
using System.Collections;

/*
 * this class represents the crouching block state.
 * this state is entered from the standing parry state is functions similarly to the crouch variant.
 */

public class BlockCrouchState1 : State1
{

    private bool blocking;
    private StateMachine1 stateMachine;

    public override void Enter()
    {
        stateMachine = gameObject.GetComponent<StateMachine1>();
        StartCoroutine(Block());
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
    IEnumerator Block()
    {
        if (blocking == true)
        {
            yield return new WaitForEndOfFrame();

        }
        yield return new WaitForEndOfFrame();

        stateMachine.SetState(StateID.Crouch);
    }
}
