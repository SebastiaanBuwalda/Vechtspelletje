using UnityEngine;
using System.Collections;

/*
 * this class represents the character walking backwards.
 * this state is entered from the idle and walking forward states when the analogue stick is tilted away from the opponent.
 */

public class WalkBackwardState : State1 {

    public override void Enter()
    {
        Debug.Log("Walk backwards state");
    }

    public override void Act()
    {
        transform.Translate(new Vector3(-5, 0, 0));
    }

    public override void Reason()
    {
        
    }

    public override void Leave()
    {
        
    }
}
