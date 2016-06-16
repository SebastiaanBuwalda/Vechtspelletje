using UnityEngine;
using System.Collections;

public class WalkForwardState2 : State2 {

    [SerializeField]
    private StateMachine2 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Vector3 moveVector;
    [SerializeField]
	private StateBasedInputs inputHandler;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip walkingSound;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 2);
    }

    public override void Act()
    {
        transform.Translate(moveVector * Time.deltaTime);
        audioSource.PlayOneShot(walkingSound);
    }

    public override void Reason()
    {
        anim.SetInteger("AnimState", 2);
		if (inputHandler.AskForLightAttack())
        {
            stateMachine.SetState(StateID2.LightSpecial);
        }
		else if (inputHandler.AskForHeavyAttack())
		{
			stateMachine.SetState(StateID2.HeavySpecial);
		}
        else if ((Input.GetAxis("Horizontal2") == 0))
        {
            stateMachine.SetState(StateID2.Idle);
        }
        else if ((Input.GetAxis("Horizontal2") < 0))
        {
            stateMachine.SetState(StateID2.WalkBackward);
        }
        else if (Input.GetButtonDown("A2"))
        {
            stateMachine.SetState(StateID2.StandLightAttack);
        }
        else if (Input.GetButtonDown("B2"))
        {
            stateMachine.SetState(StateID2.StandHeavyAttack);
        }
        else if (Input.GetButtonDown("X2"))
        {
            stateMachine.SetState(StateID2.JumpForward);
        }
    }

    public override void Leave()
    {
    }
}
