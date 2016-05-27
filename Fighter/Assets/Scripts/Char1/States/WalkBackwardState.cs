using UnityEngine;
using System.Collections;

/*
 * this class represents the character walking backwards.
 * this state is entered from the idle and walking forward states when the analogue stick is tilted away from the opponent.
 */

public class WalkBackwardState : State1 {

    private StateMachine1 stateMachine;

    void Start()
    {
        stateMachine = GetComponent<StateMachine1>();
    }

    public override void Enter()
    {
        //Debug.Log("Walk backwards state");
    }

    public override void Act()
    {
        transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);
    }

    public override void Reason()
    {
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            stateMachine.SetState(StateID.Idle);
        }else if(!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            stateMachine.SetState(StateID.WalkForward);
        }
    }

    public override void Leave()
    {
        
    }
}
