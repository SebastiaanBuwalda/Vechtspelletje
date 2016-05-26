using UnityEngine;
using System.Collections;

/*
 * this class represents the first few frames of a block and is entered when the block button is pressed while in idle.
 * from this state the character can enter any attack state or movement state without entering the blockdrop state
 * if the character is not hit while this state is active the character will enter the standing block state
 */

public class ParryStandingState : State1 {

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
