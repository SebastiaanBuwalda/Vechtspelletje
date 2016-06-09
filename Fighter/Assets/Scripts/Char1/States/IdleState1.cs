using UnityEngine;
using System.Collections;

/*
 * this class represents the default state of the character.
 * if the character is given no inputs and is not hit by anything it will assume this state.
 */

public class IdleState1 : State1 {

    [SerializeField] private StateMachine1 stateMachine;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rb;
	[SerializeField] private StateFreeInputHandler inputHandler;
<<<<<<< HEAD
    private bool inState;
    private bool leftState = true;
=======
	[SerializeField] private PositionBasedFlip positionBasedFlip;

	private bool inState = false;
>>>>>>> 2031095f918e94ed4a62c9a66eb03c50d41b34b4


    private bool grounded;

    public override void Enter()
    {
<<<<<<< HEAD
        if(leftState == true)
            anim.SetInteger("AnimState", 0);
        leftState = false;
        //Input.ResetInputAxes();
        Debug.Log("<color=purple> IDLE ENTER </color>");
        inState = true;
=======
		positionBasedFlip.enabled = true;
        anim.SetInteger("AnimState", 0);
        Input.ResetInputAxes();
>>>>>>> 2031095f918e94ed4a62c9a66eb03c50d41b34b4

        if (!anim.IsInTransition(0))
        {
            ReadInputs();
        }
    }

    public override void Act()
    {
        if (!anim.IsInTransition(0))
            ReadInputs();
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
        if(coll.gameObject.tag == GameTags.floor)
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if(coll.gameObject.tag == GameTags.floor)
        {
            grounded = false;
        }
    }

    void Update()
    {
        //limit velocity
        if(rb.velocity.x > 3.9f || rb.velocity.y > 21.7f)
        {
            rb.velocity = new Vector3(3.9f, 12.7f, 0);
        }

        if(inState)
        {
            //stateMachine.SetState(StateID.Jump);
        }
    }

    void ReadInputs()
    {
		if (inputHandler.returnHadouken ())
        {
			stateMachine.SetState (StateID.LightSpecial);
		}
		else if (inputHandler.returnHadoukenHeavy ())
		{
			stateMachine.SetState (StateID.HeavySpecial);
		}
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //walk left
            stateMachine.SetState(StateID.WalkBackward);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //walk right
            stateMachine.SetState(StateID.WalkForward);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.SetState(StateID.StandLightAttack);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("<color=red> HEAVY ATTACK </color>");
            stateMachine.SetState(StateID.StandHeavyAttack);
        }
		else if (Input.GetKeyDown(KeyCode.DownArrow) && inState == true)
		{
			stateMachine.SetState (StateID.Crouch);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && grounded == true && inState == true)
        {
            Debug.Log("<color=blue> TO JUMP </color>");
            stateMachine.SetState(StateID.Jump);
        }
    }
}
