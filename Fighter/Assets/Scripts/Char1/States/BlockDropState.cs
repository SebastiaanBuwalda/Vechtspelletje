using UnityEngine;
using System.Collections;

/* 
 * this class represents the block action. this state is entered when the block button is pressed while in the parry state, 
 * the parry state is entered when pressing the block button while in idle.
 * when in this state air and standing attacks will be blocked by the character, they will not suffer hitstun and will negate a large percentage of the damage.
 * upon letting go of the button the character will enter the dropblock state, which leaves the character open for attack.
 */

public class BlockDropState : State1 {

    public override void Enter()
    {
        
    }

    public override void Act()
    {
        
    }

    public override void Reason()
    {
        
    }

    public override void Leave()
    {
        
    }
}
