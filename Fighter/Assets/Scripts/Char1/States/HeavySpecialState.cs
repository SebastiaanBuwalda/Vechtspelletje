using UnityEngine;
using System.Collections;

/*
 * This class represents the characters standing heavy attack.
 * This attack is slower, more powerfull and easier to react to for the opponent.
 * if the opponent is hit with this attack while in hitstun he will fall to the ground.
 * if the opponent is hit with this attack while in the air he will fall to the ground.
 */

public class HeavySpecialState : State1 {

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
