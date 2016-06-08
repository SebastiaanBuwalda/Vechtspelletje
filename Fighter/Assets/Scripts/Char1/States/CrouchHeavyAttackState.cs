using UnityEngine;
using System.Collections;

/*
 * this class represents the crouch variation of the heavy attack.
 * this state is entered when the heavy attack button is pressed while in the crouch state.
 * from this state you can enter the crouch, idle, and hitstun states.
 */

public class CrouchHeavyAttackState : State1 {

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
