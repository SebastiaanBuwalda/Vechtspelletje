using UnityEngine;
using System.Collections;

/*
 * this class represents the crouch state of the character.
 * while in idle or either walking states the character will enter the crouch state if the analogue stick is tilted downwards.
 */

public class CrouchState1 : State1 {

	[SerializeField] private StateMachine1 stateMachine;
	[SerializeField] private Animator anim;
	[SerializeField] private StateFreeInputHandler inputHandler;


    public override void Enter()
    {
		anim.SetInteger("AnimState", 6);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
		
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch Up"))
        {
            ReadInputs();
        }
    }

    public override void Leave()
    {
       
    }

	void ReadInputs()
	{
		if (inputHandler.returnHadouken ())
		{
			stateMachine.SetState (StateID.LightSpecial);
		}
		else if (!Input.anyKey) 
		{
            Debug.Log("From Crouch to Idle");
			stateMachine.SetState (StateID.Idle);
		} 
		else if (Input.GetKeyDown (KeyCode.Z)) 
		{
            Input.ResetInputAxes();
			stateMachine.SetState (StateID.CrouchLightAttack);
		}
		else if (Input.GetKeyDown (KeyCode.X)) 
		{
            Input.ResetInputAxes();
			stateMachine.SetState (StateID.CrouchHeavyAttack);
		}
	}
}
