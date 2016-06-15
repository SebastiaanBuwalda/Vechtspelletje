using UnityEngine;
using System.Collections;

public class SoftLandingState2 : State2{

    [SerializeField]
    private StateMachine2 stateMachine;

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
                stateMachine.SetState(StateID2.Idle);
            StartCoroutine(SoftLandingLag());
        }

        if (rb.velocity != Vector3.zero)
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
            stateMachine.SetState(StateID2.WalkBackward);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(StateID2.WalkForward);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.SetState(StateID2.StandLightAttack);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.SetState(StateID2.StandHeavyAttack);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            stateMachine.SetState(StateID2.Crouch);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SetState(StateID2.Jump);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.RightArrow))
        {
            stateMachine.SetState(StateID2.JumpForward);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stateMachine.SetState(StateID2.JumpBackward);
        }
        else if (!Input.anyKey)
        {
            //Debug.Log("GO BACK TO IDLE FROM LANDING");
            stateMachine.SetState(StateID2.Idle);
        }
    }
}
