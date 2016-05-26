using UnityEngine;
using System.Collections;

/*
 * this state acts the same as the standing state exept that it can only be entered while pressing the block button while in the crouch state
 */

public class ParryCrouchState : State1 {

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
