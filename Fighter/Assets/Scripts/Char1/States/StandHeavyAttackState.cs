using UnityEngine;
using System.Collections;

/*
 * this class represents the standing heavy attack.
 * this state is entered when the character is in his idle state and the heavy attack button is pressed.
 */

public class StandHeavyAttackState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float lockTime;
    [SerializeField]
    private Vector3 moveVector;
    [SerializeField]
    private GameObject hitBox;
    private bool inState;

    private bool shouldMove;

	[SerializeField]
	private PositionBasedFlip positionBasedFlip;


    public override void Enter()
    {
        inState = true;
        //Input.ResetInputAxes();
        anim.SetInteger("AnimState", 4);
        shouldMove = true;
    }

    public override void Act()
    {
        anim.SetInteger("AnimState", 4);
        MoveForward();
    }

    public override void Reason()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("H Punch") && !anim.IsInTransition(0))
        {
            StartCoroutine(HeavyAtkLockTime());
        }
    }

    void MoveForward()
    {
		if (shouldMove) 
		{
			if (!positionBasedFlip.facingLeft)
				transform.Translate (moveVector * Time.deltaTime);
			else {
				transform.Translate ((moveVector*-1) * Time.deltaTime);

			}
		}
    }

    void StopMoveing()
    {
        shouldMove = false;
    }

    void ActivateHeavyHitbox()
    {
        //this method is called via animation event
        hitBox.SetActive(true);
    }

    void DeactivateHeavyHitbox()
    {
        //this method is called via animation event
        hitBox.SetActive(false);
    }

    public override void Leave()
    {
        inState = false;
        hitBox.SetActive(false);
    }

    //time untill player can move again
    IEnumerator HeavyAtkLockTime()
    {
        yield return new WaitForSeconds(lockTime);
        if(inState)
        {
            if (!Input.anyKey || Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space))
            {
                stateMachine.SetState(StateID.Idle);
                Input.ResetInputAxes();
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                stateMachine.SetState(StateID.WalkForward);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                stateMachine.SetState(StateID.WalkBackward);
            }
            Input.ResetInputAxes();
        }
        
    }
}
