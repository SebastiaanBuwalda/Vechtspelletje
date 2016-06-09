using UnityEngine;
using System.Collections;

/*
 * this class represents the soft landing action that is triggered after the character lands safely on the ground after an aerial attack.
 * This class can be compared to landing lag in other games. it leaves the character open for attack after landing with an aerial.
 */

public class SoftLandingState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float lockTime;

    [SerializeField]
    private Rigidbody rb;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 13);
        Input.ResetInputAxes();
    }

    public override void Act()
    {
        
    }

    public override void Reason()
    {
        

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Soft Landing"))
        {
            if (!Input.anyKeyDown)
                stateMachine.SetState(StateID.Idle);
            StartCoroutine(SoftLandingLag());
        }

        if(rb.velocity != Vector3.zero)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public override void Leave()
    {
        
    }

    IEnumerator SoftLandingLag()
    {
        yield return new WaitForSeconds(lockTime);
        ReadInputs();
    }

    void ReadInputs()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(StateID.WalkBackward);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(StateID.WalkForward);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.SetState(StateID.StandLightAttack);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.SetState(StateID.StandHeavyAttack);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            stateMachine.SetState(StateID.Crouch);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(StateID.Jump);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            stateMachine.SetState(StateID.JumpForward);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stateMachine.SetState(StateID.JumpBackward);
        }
        else if (!Input.anyKey)
        {
            Debug.Log("GO BACK TO IDLE FROM LANDING");
            stateMachine.SetState(StateID.Idle);
        }
    }
}