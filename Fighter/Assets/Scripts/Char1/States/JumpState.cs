using UnityEngine;
using System.Collections;

/*
 * this class represents the jump.
 * this state is entered while the jump button is pressed while in the idle or crouch state
 * from this state the character can enter the aerial versions of the light and heavy attacks as well as the falling state upon getting hit, 
 * and the idle state upon hitting the ground without using a move.
 */

public class JumpState : State1 {

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
