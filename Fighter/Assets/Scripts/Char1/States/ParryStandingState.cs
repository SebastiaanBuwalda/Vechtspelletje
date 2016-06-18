using UnityEngine;
using System.Collections;

/*
 * this class represents the first few frames of a block and is entered when the block button is pressed while in idle.
 * from this state the character can enter any attack state or movement state without entering the blockdrop state
 * if the character is not hit while this state is active the character will enter the standing block state
 */

public class ParryStandingState : State1 {
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private StateMachine1 stateMachine;
    private bool inState;

    [SerializeField]
    private float parryWindow;

    public override void Enter()
    {
        inState = true;
        anim.SetInteger("AnimState", 19);
        StartCoroutine(ParryWindow());
    }

    public override void Act()
    {
    }

    public override void Reason()
    {
      
    }

    public override void Leave()
    {
        inState = false;
    }

    IEnumerator ParryWindow()
    {
        yield return new WaitForSeconds(parryWindow);
        //parry window passed, go to blocking state if R button is still pressed, else go to idle through block drop animation
        stateMachine.SetState(StateID.StandBlock);
    }

    void OnTriggerEnter(Collider coll)
    {
        //ontriggerenter derives from monobehaviour and thus is always ran even when the statemachine is not in this state.
        //as such i keep a boolean in most states that check whenever or not the state is activated. this is the inState boolean.
        //here i prevent OnTriggerEnter from checking for collider tags when the state is not activated.
        if(inState)
        {
            if (coll.tag != GameTags.heavyCrouchHitbox || coll.tag != GameTags.lightCrouchHitbox)
            {
                //parry succesfull, read inputs to see if an action is inputted
                //take less damage?
            }
            else
            {
                //go to hitstun, attack bypassed parry because it was too low
                //take damage by checking the tag you where hit by
            }
        }
    }
}
