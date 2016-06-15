using UnityEngine;
using System.Collections;

public class AirLightAttack2 : State2 {

    [SerializeField]
    private StateMachine2 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject hitBox;
    [SerializeField]
    private Rigidbody rb;

    private bool inState;

    public override void Enter()
    {
        anim.SetInteger("AnimState", 15);
        inState = true;
    }

    public override void Act()
    {

    }

    public override void Reason()
    {
        //clamp jump velocity
        if (rb.velocity.y > 12.7f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 12.7f, rb.velocity.z);
        }
    }

    public override void Leave()
    {
        inState = false;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == GameTags.floor && inState == true)
        {
            stateMachine.SetState(StateID2.SoftLanding);
        }
    }

    void ActivateAirLightHitbox()
    {

    }

    void DeactivateAirLightHitbox()
    {

    }
}
