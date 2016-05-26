using UnityEngine;
using System.Collections;

/*
 * this class represents the aerial version of the light attack state.
 * this state is entered when the light attack button is pressed while in the jump state.
 * upon landing while in this state the soft landing state will be entered.
 */

public class AirLightAttack : State1 {

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
