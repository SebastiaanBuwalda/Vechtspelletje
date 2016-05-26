using UnityEngine;
using System.Collections;

/*
 * this class represents the soft landing action that is triggered after the character lands safely on the ground after an aerial attack.
 * This class can be compared to landing lag in other games. it leaves the character open for attack after landing with an aerial.
 */

public class SoftLandingState : State1 {

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
