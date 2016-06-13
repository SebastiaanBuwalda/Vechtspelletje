using UnityEngine;
using System.Collections;

/*
 * this class represents the crouch variation of the heavy attack.
 * this state is entered when the heavy attack button is pressed while in the crouch state.
 * from this state you can enter the crouch, idle, and hitstun states.
 */

public class CrouchHeavyAttackState : State1 {

	[SerializeField] private StateMachine1 stateMachine;
	[SerializeField] private Animator anim;
	[SerializeField] private float lockTime;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip sweepSound;

    private bool inState;

	public override void Enter()
	{
        inState = true;
		anim.SetInteger("AnimState", 10);
		audioSource.PlayOneShot (sweepSound);
	}

	public override void Act()
	{

	}

	public override void Reason()
	{
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch kick") && !anim.IsInTransition(0))
        {
            StartCoroutine(HeavyAtkLockTime());
        }
	}

	public override void Leave()
	{
        inState = false;
	}

	IEnumerator HeavyAtkLockTime()
	{
		yield return new WaitForSeconds(lockTime);
        if(inState)
        {
			if (Input.GetAxis("Vertical")>=0)
			{
				//Input.ResetInputAxes();
				stateMachine.SetState(StateID.Idle);
			}
			else if (Input.GetAxis("Vertical")<0)
			{
				//Debug.Log("Go back to crouch");
				stateMachine.SetState(StateID.Crouch);
			}
        }
		
	}
}
