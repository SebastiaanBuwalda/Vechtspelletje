using UnityEngine;
using System.Collections;

public class JumpState2 : State2 {

    [SerializeField]
    private StateMachine2 stateMachine;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Vector3 jumpVector;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private PositionBasedFlip positionBasedFlip;

    private bool inState;

    private Vector3 maxJumpVel = new Vector3(0, 12.7f, 0);

    void Start()
    {

        Physics.gravity = new Vector3(0, -25, 0);
    }

    public override void Enter()
    {
        anim.SetInteger("AnimState", 5);
        positionBasedFlip.enabled = false;
        Input.ResetInputAxes();
        rb.AddForce(jumpVector, ForceMode.Impulse);

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
        if (rb.velocity.y > 12.7f)
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
        if (coll.gameObject.tag == "Floor" && inState == true)
        {
            stateMachine.SetState(StateID2.Idle);
            audioSource.PlayOneShot(jumpSound);
        }
    }

    void Update()
    {
        if (inState)
            anim.SetInteger("AnimState", 5);
    }

    void ReadInputs()
    {
        if (Input.GetButtonDown("A2"))
        {
            stateMachine.SetState(StateID2.AirLightAttack);
        }
        else if (Input.GetButtonDown("B2"))
        {
            stateMachine.SetState(StateID2.AirHeavyAttack);
        }
    }
}
