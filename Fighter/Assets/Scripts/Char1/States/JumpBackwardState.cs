﻿using UnityEngine;
using System.Collections;

/*
 * this class represents the jump forward state.
 * it is the same as the regular jump state exept that you jump backward instead of straight up.
 */

public class JumpBackwardState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Vector3 jumpVector;
    [SerializeField]
    private Animator anim;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip jumpSound;
	[SerializeField] private PositionBasedFlip positionBasedFlip;


    private bool inState;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 5);
		positionBasedFlip.enabled = false;
        Input.ResetInputAxes();
        rb.AddForce(jumpVector, ForceMode.Impulse);
        
        inState = true;
    }

    public override void Act()
    {
        anim.SetInteger("AnimState", 5);
    }

    public override void Reason()
    {
        anim.SetInteger("AnimState", 5);
        //clamp jump velocity
        if (rb.velocity.y > 12.7f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 12.7f, rb.velocity.z);
        }

        ReadInputs();
    }

    public override void Leave()
    {
        inState = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Floor" && inState == true)
        {
            stateMachine.SetState(StateID.Idle);
			audioSource.PlayOneShot (jumpSound);
        }
    }

    void ReadInputs()
    {
		if (Input.GetButtonDown("A"))
		{
			stateMachine.SetState(StateID.AirLightAttack);
		}
		else if (Input.GetButtonDown("B"))
		{
			stateMachine.SetState(StateID.AirHeavyAttack);
		}
    }
}
