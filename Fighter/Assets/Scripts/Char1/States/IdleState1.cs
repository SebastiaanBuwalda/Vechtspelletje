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

    private bool inState;

	private FightingInput hadouken = new FightingInput(new string[] { "down","right", "Fire1"});


    private bool grounded;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 0);
        Input.ResetInputAxes();

        if (!anim.IsInTransition(0))
        {
            ReadInputs();
        }
        Debug.Log("IDLE ENTER");
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
            stateMachine.SetState(StateID.Jump);
        }
    }

    void ReadInputs()
    {
        
		if (hadouken.GetInput ())
		{
			stateMachine.SetState (StateID.LightSpecial);
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
            Debug.Log("From Idle to LightAttack");
            stateMachine.SetState(StateID.StandLightAttack);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.SetState(StateID.StandHeavyAttack);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            Debug.Log("Idle Jump");
            stateMachine.SetState(StateID.Jump);
        }
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			stateMachine.SetState (StateID.Crouch);
		}
    }
}
