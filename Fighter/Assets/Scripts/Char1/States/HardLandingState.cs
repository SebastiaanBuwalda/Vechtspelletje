using UnityEngine;
using System.Collections;

/* 
 * this class represents the action that happens when the player hits the ground after having entered the falling state. (a little body bounce opon hitting the ground).
 * From this state the character enters the lying down state when the animation is finished.
 */

public class HardLandingState : State1 {

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
