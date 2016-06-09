using UnityEngine;
using System.Collections;

/*
 * this class represents the aerial version of the light attack state.
 * this state is entered when the light attack button is pressed while in the jump state.
 * upon landing while in this state the soft landing state will be entered.
 */

public class AirLightAttack : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
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
            stateMachine.SetState(StateID.SoftLanding);
        }
    }

    void ActivateAirLightHitbox()
    {

    }

    void DeactivateAirLightHitbox()
    {

    }
}
