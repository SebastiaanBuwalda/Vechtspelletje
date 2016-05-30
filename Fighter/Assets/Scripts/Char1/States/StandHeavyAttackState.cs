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
    [SerializeField]
    private Vector3 moveVector;
    [SerializeField]
    private GameObject hitBox;

    private bool shouldMove;


    public override void Enter()
    {
        anim.SetInteger("AnimState", 4);
        shouldMove = true;
    }

    public override void Act()
    {
        anim.SetInteger("AnimState", 4);
        MoveForward();
        
    }

    public override void Reason()
    {
        if(!Input.GetKeyDown(KeyCode.X))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("H Punch"))
            {
                StartCoroutine(HeavyAtkLockTime());
            }
        }
    }

    void MoveForward()
    {
        if(shouldMove)
            transform.Translate(moveVector * Time.deltaTime);
    }

    void StopMoveing()
    {
        shouldMove = false;
    }

    void ActivateHeavyHitbox()
    {
        //this method is called via animation event
        hitBox.SetActive(true);
    }

    void DeactivateHeavyHitbox()
    {
        //this method is called via animation event
        hitBox.SetActive(false);
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
