using UnityEngine;
using System.Collections;

public class CrouchHeavyAttack2 : State2 {

    [SerializeField]
    private StateMachine2 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float lockTime;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip sweepSound;

    private bool inState;

    public override void Enter()
    {
        inState = true;
        anim.SetInteger("AnimState", 10);
        audioSource.PlayOneShot(sweepSound);
    }

    public override void Act()
    {

    }

    public override void Reason()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch kick") && !anim.IsInTransition(0))
        {
            StartCoroutine(HeavyAtkLockTime());
        }
    }

    public override void Leave()
    {
        inState = false;
    }

    IEnumerator HeavyAtkLockTime()
    {
        yield return new WaitForSeconds(lockTime);
        if (inState)
        {
            if (Input.GetAxis("Vertical") >= 0)
            {
                //Input.ResetInputAxes();
                stateMachine.SetState(StateID2.Idle);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                //Debug.Log("Go back to crouch");
                stateMachine.SetState(StateID2.Crouch);
            }
        }

    }
}
