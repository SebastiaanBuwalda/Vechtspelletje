using UnityEngine;
using System.Collections;

public class JumpForwardState2 : State2 {

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
            rb.velocity = new Vector3(rb.velocity.x, 12.7f, rb.velocity.z);
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

    void ReadInputs()
    {
        if (Input.GetButtonDown("A"))
        {
            stateMachine.SetState(StateID2.AirLightAttack);
        }
        else if (Input.GetButtonDown("B"))
        {
            stateMachine.SetState(StateID2.AirHeavyAttack);
        }
    }
}
