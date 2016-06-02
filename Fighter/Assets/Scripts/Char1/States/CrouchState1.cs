using UnityEngine;
using System.Collections;

/*
 * this class represents the crouch state of the character.
 * while in idle or either walking states the character will enter the crouch state if the analogue stick is tilted downwards.
 */

public class CrouchState1 : State1 {

	[SerializeField] private StateMachine1 stateMachine;
	[SerializeField] private Animator anim;


    public override void Enter()
    {
		anim.SetInteger("AnimState", 6);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
		ReadInputs ();
    }

    public override void Leave()
    {
       
    }

	void ReadInputs()
	{
		if (!Input.anyKey) 
		{
			stateMachine.SetState (StateID.Idle);
		} 
		else if (Input.GetKeyDown (KeyCode.Z)) 
		{
			stateMachine.SetState (StateID.CrouchLightAttack);
		}
		else if (Input.GetKeyDown (KeyCode.X)) 
		{
			stateMachine.SetState (StateID.CrouchHeavyAttack);
		}
	}
}
