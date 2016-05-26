using UnityEngine;
using System.Collections;

/*
 * this class represents the crouch block. 
 * this state is entered when the character is in his crouchparry state and is not hit. the crouch parry state 
 * can be entered while the character is in the crouch state and the block button is pressed
 */

public class BlockCrouchState1 : State1 {

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
