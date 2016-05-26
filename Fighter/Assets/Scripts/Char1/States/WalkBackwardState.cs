using UnityEngine;
using System.Collections;

/*
 * this class represents the character walking backwards.
 * this state is entered from the idle and walking forward states when the analogue stick is tilted away from the opponent.
 */

public class WalkBackwardState : State1 {

    public override void Enter()
    {
        base.Enter();
    }

    public override void Act()
    {
        throw new System.NotImplementedException();
    }

    public override void Reason()
    {
        throw new System.NotImplementedException();
    }

    public override void Leave()
    {
        base.Leave();
    }
}
