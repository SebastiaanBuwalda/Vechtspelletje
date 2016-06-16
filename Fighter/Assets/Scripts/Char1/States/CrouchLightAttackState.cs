using UnityEngine;
using System.Collections;

/*
 * this class represents the crouching variation of the light attack.
 * this state is entered when the light attack button is pressed while in the crouch state.
 */

public class CrouchLightAttackState : State1
{

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float lockTime;

    private bool inState;

    public override void Enter()
    {
        inState = true;
        anim.SetInteger("AnimState", 9);
    }

    public override void Act()
    {

    }

    public override void Reason()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch punch"))
        {
            StartCoroutine(LightAtkLockTime());
        }
    }

    public override void Leave()
    {
        inState = false;
    }

    IEnumerator LightAtkLockTime()
    {
        yield return new WaitForSeconds(lockTime);
        if (inState)
        {
            if (Input.GetAxis("Vertical") >= 0)
            {
                //Input.ResetInputAxes();
                stateMachine.SetState(StateID.Idle);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                //Debug.Log("Go back to crouch");
                if (!Input.anyKey)
                {
                    Input.ResetInputAxes();
                    stateMachine.SetState(StateID.Idle);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    stateMachine.SetState(StateID.Crouch);
                }
            }

        }
    }
}
