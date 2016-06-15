using UnityEngine;
using System.Collections;

public class StandHeavyAttackState2 : State2 {

    [SerializeField]
    private StateMachine2 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float lockTime;
    [SerializeField]
    private Vector3 moveVector;
    [SerializeField]
    private GameObject hitBox;
    private bool inState;

    private bool shouldMove;

    [SerializeField]
    private PositionBasedFlip positionBasedFlip;


    public override void Enter()
    {
        inState = true;
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
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("H Punch") && !anim.IsInTransition(0))
        {
            StartCoroutine(HeavyAtkLockTime());
        }
    }

    void MoveForward()
    {
        if (shouldMove)
        {
            if (!positionBasedFlip.facingLeft)
                transform.Translate(moveVector * Time.deltaTime);
            else
            {
                transform.Translate((moveVector * -1) * Time.deltaTime);

            }
        }
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
        inState = false;
        //Debug.Log("HEAVY ATTACK LEAVE");
    }

    //time untill player can move again
    IEnumerator HeavyAtkLockTime()
    {
        yield return new WaitForSeconds(lockTime);
        if (inState)
        {
            if (!Input.anyKey || Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space))
            {
                stateMachine.SetState(StateID2.Idle);
                Input.ResetInputAxes();
                //Debug.Log("<color=green> TO IDLE FROM HEAVY ATTACK </color>");
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                stateMachine.SetState(StateID2.WalkForward);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                stateMachine.SetState(StateID2.WalkBackward);
            }
            Input.ResetInputAxes();
        }
    }
}
