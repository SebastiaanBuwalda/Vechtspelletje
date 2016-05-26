using UnityEngine;
using System.Collections;

/*
 * This class represents the light attack state.
 * This attack is faster, weaker but has combo potential
 * if the opponent is hit by this attack he will enter hitstun.
 */

public class LightSpecialState : State1 {

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
