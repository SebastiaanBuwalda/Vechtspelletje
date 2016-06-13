﻿using UnityEngine;
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
		else if (Input.GetAxis("Vertical")==0) 
		{
			stateMachine.SetState (StateID.Idle);
		} 
		else if (Input.GetButtonDown("A"))
		{
<<<<<<< HEAD
			stateMachine.SetState (StateID.CrouchLightAttack);
=======
			stateMachine.SetState(StateID.CrouchLightAttack);
>>>>>>> abc6027324aaedc35212965fb8754606580f3c22
		}
		else if (Input.GetButtonDown("B"))
		{
<<<<<<< HEAD
            //Input.ResetInputAxes();
			stateMachine.SetState (StateID.CrouchHeavyAttack);
=======
			stateMachine.SetState(StateID.CrouchHeavyAttack);
>>>>>>> abc6027324aaedc35212965fb8754606580f3c22
		}
	}
}
