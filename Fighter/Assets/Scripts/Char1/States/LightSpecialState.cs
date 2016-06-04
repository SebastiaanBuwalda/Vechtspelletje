using UnityEngine;
using System.Collections;

/*
 * This class represents the light special state.
 * This attack is faster, weaker but has combo potential
 * if the opponent is hit by this attack he will enter hitstun.
 */

public class LightSpecialState : State1 {

	[SerializeField] private StateMachine1 stateMachine;
	[SerializeField] private Animator anim;
	[SerializeField] private float lockTime;

    public override void Enter()
    {
		anim.SetInteger("AnimState", 17);

    }

    public override void Act()
    {
		
    }

    public override void Reason()
    {
		if(!Input.GetKeyDown(KeyCode.Z))
		{
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("L Projectile"))
			{
				StartCoroutine(LightAtkLockTime());
			}
		}
    }

    public override void Leave()
    {
       
    }

	IEnumerator LightAtkLockTime()
	{
		yield return new WaitForSeconds(lockTime);
		if(!Input.anyKey||Input.GetKey(KeyCode.Z))
			stateMachine.SetState(StateID.Idle);
	}
}
