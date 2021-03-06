﻿using UnityEngine;
using System.Collections;

/*
 * this class represents the character walking backwards.
 * this state is entered from the idle and walking forward states when the analogue stick is tilted away from the opponent.
 */

public class WalkBackwardState : State1 {

    [SerializeField] private StateMachine1 stateMachine;
    [SerializeField] private Animator anim;
    [SerializeField] private Vector3 moveVector;
	[SerializeField] private StateBasedInputs inputHandler;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip walkSound;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 1);
    }

    public override void Act()
    {
        transform.Translate(moveVector * Time.deltaTime);
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(walkSound);
    }

    public override void Reason()
    {
        
        anim.SetInteger("AnimState", 1);
		if (inputHandler.AskForLightAttack()) 
		{
			stateMachine.SetState (StateID.LightSpecial);
		}
		else if (inputHandler.AskForHeavyAttack ())
		{
			stateMachine.SetState (StateID.HeavySpecial);
		}
		else if(Input.GetAxis("Horizontal")==0)
        {
            stateMachine.SetState(StateID.Idle);
		}else if(Input.GetAxis("Horizontal")>0)
        {
            stateMachine.SetState(StateID.WalkForward);
        }
		else if(Input.GetButtonDown("A"))
        {
            stateMachine.SetState(StateID.StandLightAttack);
        }
		else if(Input.GetButtonDown("B"))
        {
            stateMachine.SetState(StateID.StandHeavyAttack);
        }
		else if(Input.GetButtonDown("X"))
        {
            stateMachine.SetState(StateID.JumpBackward);
        }else if(Input.GetKey(KeyCode.R))
        {
            stateMachine.SetState(StateID.StandParry);
        }
    }

    public override void Leave()
    {

    }
}
