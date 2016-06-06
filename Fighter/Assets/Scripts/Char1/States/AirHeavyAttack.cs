using UnityEngine;
using System.Collections;

/*
 * this class represents the aerial version the the heavy attack.
 * this state is entered when the character is in the jump state and the heavy attack button is pressed.
 * upon landing on the ground in this state the character will enter the soft landing state.
 */

public class AirHeavyAttack : State1 {

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
        //Debug.Log("AirHeavyAttack ENTER");
        anim.SetInteger("AnimState", 16);

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

    void ActivateAirHeavyHitbox()
    {
        hitBox.SetActive(true);
    }

    void DeactivateAirHeavyHitbox()
    {
        hitBox.SetActive(false);
    }
}
