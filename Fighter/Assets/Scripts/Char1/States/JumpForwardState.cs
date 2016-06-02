﻿using UnityEngine;
using System.Collections;

/*
 * this class represents the jump forward state.
 * it is the same as the regular jump state exept that you jump forward instead of straight up.
 */

public class JumpForwardState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Vector3 jumpVector;
    [SerializeField]
    private Animator anim;

    private bool inState;


    public override void Enter()
    {
        rb.AddForce(jumpVector, ForceMode.Impulse);
        anim.SetInteger("AnimState", 5);
        inState = true;
    }

    public override void Act()
    {
        //Debug.Log(rb.velocity);
        anim.SetInteger("AnimState", 5);
    }

    public override void Reason()
    {
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
            stateMachine.SetState(StateID.Idle);
        }
    }

    void ReadInputs()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.SetState(StateID.AirLightAttack);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.SetState(StateID.AirHeavyAttack);
        }
    }
}
