﻿using UnityEngine;
using System.Collections;

/*
 * this class represents hitstun. this state is entered when the character is hit by a heavy or light attack while in idle and also by a light attack while already in hitstun.
 * after a set few frames the character enters the parry state.
 */

public class HitstunState : State1
{

    //delegate to loosly couple the clasess and still take damage

    //time variable to determine the time the player stays in the histstun state
    private float stunTimer = 0.01f;
    [SerializeField]
    private StateMachine1 stateMachine;
    private bool inState;
    private bool OnGround;
    private Rigidbody rb;
    [SerializeField]
    private Animator anim;
    private bool blocking;

    //make hitstun longer when the atack is heavy
    private int atackLevel;
    public int AtackLevel
    {
        get { return atackLevel; }
        set { atackLevel = value; }
    }

    public override void Enter()
    {
        //stunTimer = stunTimer * atackLevel;
        stunTimer = stunTimer;
        rb = gameObject.GetComponent<Rigidbody>();
        stateMachine = gameObject.GetComponent<StateMachine1>();

        anim.SetInteger("AnimState", 22);

        StartCoroutine(StayTimer(stunTimer));
        Debug.Log("Hitstun enter");
        Debug.Log(atackLevel);
        inState = true;

    }

    public override void Act()
    {

    }
    public override void Reason()
    {
        

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == GameTags.floor)
        {
            OnGround = true;
        }
        

    }
    void OnCollisionExit(Collision collision)
    {
        if(inState)
        {
            OnGround = false;
        }
    }
    public override void Leave()
    {
        inState = false;
        Debug.Log("Leave Hitstun");
    }

    IEnumerator StayTimer(float stayTime)
    {
        rb.isKinematic = true;
        Debug.Log("stunned");
        yield return new WaitForSeconds(0.05f);

        //leave the hitstunstate to the state where the player should be either the idle state or the jump state
        rb.isKinematic = false;
        switch (OnGround)
        {
            case true:
               stateMachine.SetState(StateID.Idle);
                break;
            case false:
                stateMachine.SetState(StateID.Falling);
                break;
            default:
                break;
        }
    }

  
    }

