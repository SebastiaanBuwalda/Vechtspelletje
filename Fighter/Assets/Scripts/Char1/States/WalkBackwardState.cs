using UnityEngine;
using System.Collections;

/*
 * this class represents the character walking backwards.
 * this state is entered from the idle and walking forward states when the analogue stick is tilted away from the opponent.
 */

public class WalkBackwardState : State1 {

    [SerializeField] private StateMachine1 stateMachine;
    [SerializeField] private Animator anim;
    [SerializeField] private Vector3 moveVector;
	private FightingInput hadouken = new FightingInput(new string[] {"down","right", "Fire1"});

    public override void Enter()
    {
        anim.SetInteger("AnimState", 1);
    }

    public override void Act()
    {
        transform.Translate(moveVector * Time.deltaTime);
    }

    public override void Reason()
    {
        anim.SetInteger("AnimState", 1);
		if (hadouken.GetInput ())
		{
			stateMachine.SetState (StateID.LightSpecial);
		}else if(Input.GetAxis("Horizontal")==0)
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
        }
    }

    public override void Leave()
    {
        
    }
}
