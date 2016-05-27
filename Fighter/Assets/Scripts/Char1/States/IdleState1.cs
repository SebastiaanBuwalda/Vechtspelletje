using UnityEngine;
using System.Collections;

/*
 * this class represents the default state of the character.
 * if the character is given no inputs and is not hit by anything it will assume this state.
 */

public class IdleState1 : State1 {

    public override void Enter()
    {
        Debug.Log("Entered Idle State");
    }

    public override void Act()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            //walk left
            GetComponent<StateMachine1>().SetState(StateID.WalkBackward);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            //walk right
            GetComponent<StateMachine1>().SetState(StateID.WalkForward);
        }
    }

    public override void Reason()
    {
        
    }

    public override void Leave()
    {
        
    }
}
