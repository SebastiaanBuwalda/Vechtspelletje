using UnityEngine;
using System.Collections;

public class CrouchState2 : State2 {

    [SerializeField]
    private StateMachine2 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private StateBasedInputs inputHandler;


    public override void Enter()
    {
        anim.SetInteger("AnimState", 6);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch Up"))
        {
            ReadInputs();
        }
    }

    public override void Leave()
    {
        Debug.Log("Leaving Crouch");
    }

    void ReadInputs()
    {

		if (inputHandler.AskForLightAttack())
        {
            stateMachine.SetState(StateID2.LightSpecial);
        }
		else if (inputHandler.AskForHeavyAttack())
		{
			stateMachine.SetState(StateID2.LightSpecial);
		}
        else if (Input.GetAxis("Vertical2") == 0)
        {
            Input.ResetInputAxes();
            stateMachine.SetState(StateID2.Idle);
        }
        else if (Input.GetButtonDown("A2"))
        {
            stateMachine.SetState(StateID2.CrouchLightAttack);
        }
        else if (Input.GetButtonDown("B2"))
        {
            //Input.ResetInputAxes();
            stateMachine.SetState(StateID2.CrouchHeavyAttack);
        }
        else if (Input.GetAxis("Horizontal2") > 0.2f)
        {
            stateMachine.SetState(StateID2.WalkForward);
        }
        else if (Input.GetAxis("Horizontal2") < -0.2f)
        {
            stateMachine.SetState(StateID2.WalkBackward);
        }
    }
}
