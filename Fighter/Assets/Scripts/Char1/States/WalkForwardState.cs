using UnityEngine;
using System.Collections;

/*
 * this class represents the character walking forward.
 * this state is entered when the analogue stick is tilted towards the opponent in either the idle or walking backwards state.
 */

public class WalkForwardState : State1 {

    public override void Enter()
    {
        Debug.Log("Walk forwards state");
    }

    public override void Act()
    {
        
    }

    public override void Reason()
    {
        
    }

    public override void Leave()
    {
        
    }
}
