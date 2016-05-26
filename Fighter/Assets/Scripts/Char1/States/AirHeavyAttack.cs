using UnityEngine;
using System.Collections;

/*
 * this class represents the aerial version the the heavy attack.
 * this state is entered when the character is in the jump state and the heavy attack button is pressed.
 * upon landing on the ground in this state the character will enter the soft landing state.
 */

public class AirHeavyAttack : State1 {

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
