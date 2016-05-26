using UnityEngine;
using System.Collections;

/*
 * this class represents the falling state. the character enters this state when hit out of the air or when hit by a heavy attack while in hitstun.
 * when the character hits the ground in this state he enters the hard landing state
 */

public class FallingState : State1 {

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
