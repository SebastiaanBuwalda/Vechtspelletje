using UnityEngine;
using System.Collections;

/*
 * this class represents the jump.
 * this state is entered while the jump button is pressed while in the idle or crouch state
 * from this state the character can enter the aerial versions of the light and heavy attacks as well as the falling state upon getting hit, 
 * and the idle state upon hitting the ground without using a move.
 */

public class JumpState : State1 {

    [SerializeField] private StateMachine1 stateMachine;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 jumpVector;
    [SerializeField] private Animator anim;

    private bool inState;

    private Vector3 maxJumpVel = new Vector3(0, 12.7f, 0);

    void Start()
    {
        Physics.gravity = new Vector3(0, -25, 0);
    }

    public override void Enter()
    {
        Input.ResetInputAxes();
        rb.AddForce(jumpVector, ForceMode.Impulse);
        anim.SetInteger("AnimState", 5);
        inState = true;
    }
    
    public override void Act()
    {
        anim.SetInteger("AnimState", 5);
    }

    public override void Reason()
    {
        anim.SetInteger("AnimState", 5);
        //cap max jump velocity
        if(rb.velocity.y > 12.7f)
        {
            rb.velocity = maxJumpVel;
        }

        ReadInputs();
    }

    public override void Leave()
    {
        inState = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Floor" && inState == true)
        {
            Debug.Log("GO BACK TO IDLE FROM JUMP");
            stateMachine.SetState(StateID.Idle);
        }
    }

    void Update()
    {
        if(inState)
            anim.SetInteger("AnimState", 5);
    }

    void ReadInputs()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //Debug.Log("Pressed Z");
            stateMachine.SetState(StateID.AirLightAttack);
            
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            //Debug.Log("Pressed X");
            stateMachine.SetState(StateID.AirHeavyAttack);
            
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("AnimState", 5);
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetInteger("AnimState", 5);
        }
    }
}
