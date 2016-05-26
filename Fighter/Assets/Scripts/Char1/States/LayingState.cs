using UnityEngine;
using System.Collections;

/*
 * this class represents the laying down action that is performed after the player has fallen to the ground.
 * while in this state the character will simply lay on the ground for a bit untill he enters the getup state. 
 * The character will be forced into the getup state after a set time to avoid stalling.
 */

public class LayingState : State1 {

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
