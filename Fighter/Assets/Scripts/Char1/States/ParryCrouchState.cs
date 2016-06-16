using UnityEngine;
using System.Collections;

/*
 * this class represents the first few frames of a block and is entered when the block button is pressed while in idle.
 * from this state the character can enter any attack state or movement state without entering the blockdrop state
 * if the character is not hit while this state is active the character will enter the standing block state
 */

public class ParryCrouchState : State1
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float parryWindow;
    [SerializeField]
    private StateMachine1 stateMachine;
    private bool inState;
    private bool release;
    private bool blocking;



    public override void Enter()
    {
        inState = true;
        anim.SetInteger("AnimState", 20);
        blocking = false;
        parryWindow = 1f;
        StartCoroutine(ParryBlockTime());

    }

    public override void Act()
    {
    }

    public override void Reason()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            blocking = true;
        }

    }

    public override void Leave()
    {
        inState = false;
        Debug.Log("leave");
    }

    IEnumerator ParryBlockTime()
    {
        //succesfull parry

        Debug.Log("parry");
        yield return new WaitForSeconds(parryWindow);
        //just blocking
        Debug.Log("block");

        yield return new WaitForEndOfFrame();
        stateMachine.SetState(StateID.CrouchBlock);
    }
}
