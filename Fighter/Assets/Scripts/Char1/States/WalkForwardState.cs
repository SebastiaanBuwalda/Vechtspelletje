using UnityEngine;
using System.Collections;

/*
 * this class represents the character walking forward.
 * this state is entered when the analogue stick is tilted towards the opponent in either the idle or walking backwards state.
 */

public class WalkForwardState : State1 {

    private StateMachine1 stateMachine;

    void Start()
    {
        stateMachine = GetComponent<StateMachine1>();
    }

    public override void Enter()
    {
        //Debug.Log("Walk forwards state");
    }

    public override void Act()
    {
        
        transform.Translate(new Vector3(2, 0, 0) * Time.deltaTime);
    }

    public override void Reason()
    {
        
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            stateMachine.SetState(StateID.Idle);
        }
        else if (!Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            stateMachine.SetState(StateID.WalkBackward);
        }
    }

    public override void Leave()
    {
    }
}
