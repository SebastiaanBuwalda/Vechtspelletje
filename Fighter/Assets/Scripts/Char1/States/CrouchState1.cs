using UnityEngine;
using System.Collections;

/*
 * this class represents the crouch state of the character.
 * while in idle or either walking states the character will enter the crouch state if the analogue stick is tilted downwards.
 */

public class CrouchState1 : State1 {

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
