using UnityEngine;
using System.Collections;

/*
 * This class represents the light special state.
 * This attack is faster, weaker but has combo potential
 * if the opponent is hit by this attack he will enter hitstun.
 */

public class LightSpecialState : State1 
{

	[SerializeField] private StateMachine1 stateMachine;
	[SerializeField] private Animator anim;
	[SerializeField] private float lockTime;
	[SerializeField] private GameObject fireball;
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip fireballSound;
	[SerializeField] private PositionBasedFlip positionBasedFlip;

    public override void Enter()
    {
		anim.SetInteger ("AnimState", 17);
    }

    public override void Act()
    {
		
    }

    public override void Reason()
    {
		if(!Input.GetKeyDown(KeyCode.Z))
		{
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("L Projectile") && !anim.IsInTransition(0))
			{
				StartCoroutine(LightAtkLockTime());
			}
		}
	}

    public override void Leave()
    {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("L Projectile")) {
			audioSource.PlayOneShot (fireballSound);
			GameObject temp = ObjectPool.instance.GetObjectForType("HadoukenLight", false);
			if (positionBasedFlip.FacingLeft) {
				temp.gameObject.transform.position = new Vector3 (this.transform.position.x - 1, transform.position.y + 1.68f, this.transform.position.z);
				Vector3 hadoukenVector = temp.gameObject.GetComponent<MoveWithVector> ().MoveVector;
				temp.gameObject.GetComponent<MoveWithVector> ().MoveVector = new Vector3 (hadoukenVector.x * -1, hadoukenVector.y, hadoukenVector.z);
			} else {
				temp.gameObject.transform.position = new Vector3 (this.transform.position.x + 1, transform.position.y + 1.68f, this.transform.position.z);
			}
		}
    }

	IEnumerator LightAtkLockTime()
	{
		yield return new WaitForSeconds(lockTime);
		if (!Input.anyKey)
		{
			
			stateMachine.SetState (StateID.Idle);
		}
	}
}
