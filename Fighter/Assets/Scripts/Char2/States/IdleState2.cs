using UnityEngine;
using System.Collections;

public class IdleState2 : State2 {

    [SerializeField]
    private StateMachine2 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private StateFreeInputHandler inputHandler;
    private bool inState;
    private bool leftState = true;
    [SerializeField]
    private PositionBasedFlip positionBasedFlip;


    private bool grounded;

    public override void Enter()
    {
        if (leftState == true)
            anim.SetInteger("AnimState", 0);
        leftState = false;

        inState = true;
        positionBasedFlip.enabled = true;
        Input.ResetInputAxes();
    }

    public override void Act()
    {
        if (!anim.IsInTransition(0))
        {
            ReadInputs();
        }
    }

    public override void Reason()
    {
        anim.SetInteger("AnimState", 0);
    }

    public override void Leave()
    {
        inState = false;
        leftState = true;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == GameTags.floor)
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == GameTags.floor)
        {
            grounded = false;
        }
    }

    void Update()
    {
        //limit velocity
        if (rb.velocity.x > 3.9f || rb.velocity.y > 21.7f)
        {
            rb.velocity = new Vector3(3.9f, 12.7f, 0);
        }

        if (inState)
        {
            //stateMachine.SetState(StateID.Jump);
        }
    }

    void ReadInputs()
    {
        if (inputHandler.returnHadouken())
        {
            stateMachine.SetState(StateID2.LightSpecial);
        }
        else if (inputHandler.returnHadoukenHeavy())
        {
            stateMachine.SetState(StateID2.HeavySpecial);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            //walk left
            stateMachine.SetState(StateID2.WalkBackward);

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            //walk right
            stateMachine.SetState(StateID2.WalkForward);
        }
        else if (Input.GetButtonDown("A"))
        {
            stateMachine.SetState(StateID2.StandLightAttack);
        }
        else if (Input.GetButtonDown("B"))
        {
            stateMachine.SetState(StateID2.StandHeavyAttack);
        }
        else if (((Input.GetAxis("Vertical") < -0.1)) && inState == true)
        {
            stateMachine.SetState(StateID2.Crouch);
        }
        else if (Input.GetButtonDown("X") && grounded == true && inState == true)
        {
            Debug.Log("Jump from idle");
            stateMachine.SetState(StateID2.Jump);
        }

    }
}
