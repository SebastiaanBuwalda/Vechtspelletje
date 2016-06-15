using UnityEngine;
using System.Collections;

public class WalkBackwardState2 : State2 {

    [SerializeField]
    private StateMachine2 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Vector3 moveVector;
    private FightingInput hadouken = new FightingInput(new string[] { "down", "right", "Fire1" });

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
        if (hadouken.GetInput())
        {
            stateMachine.SetState(StateID2.LightSpecial);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            stateMachine.SetState(StateID2.Idle);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            stateMachine.SetState(StateID2.WalkForward);
        }
        else if (Input.GetButtonDown("A"))
        {
            stateMachine.SetState(StateID2.StandLightAttack);
        }
        else if (Input.GetButtonDown("B"))
        {
            stateMachine.SetState(StateID2.StandHeavyAttack);
        }
        else if (Input.GetButtonDown("X"))
        {
            stateMachine.SetState(StateID2.JumpBackward);
        }
    }

    public override void Leave()
    {

    }
}
