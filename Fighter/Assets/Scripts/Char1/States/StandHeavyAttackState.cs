using UnityEngine;
using System.Collections;

/*
 * this class represents the standing heavy attack.
 * this state is entered when the character is in his idle state and the heavy attack button is pressed.
 */

public class StandHeavyAttackState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float lockTime;


    public override void Enter()
    {
        print("standing heavy attack enter");
        anim.SetInteger("AnimState", 4);
    }

    public override void Act()
    {
        
    }

    public override void Reason()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("H Punch"))
        {
            StartCoroutine(HeavyAtkLockTime());
        }
    }

    public override void Leave()
    {
        
    }

    //time untill player can move again
    IEnumerator HeavyAtkLockTime()
    {
        yield return new WaitForSeconds(lockTime);
        stateMachine.SetState(StateID.Idle);
    }
}
