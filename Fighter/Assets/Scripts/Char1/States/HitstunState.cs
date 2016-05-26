using UnityEngine;
using System.Collections;

/*
 * this class represents hitstun. this state is entered when the character is hit by a heavy or light attack while in idle and also by a light attack while already in hitstun.
 * after a set few frames the character enters the parry state.
 */

public class HitstunState : State1 {

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
