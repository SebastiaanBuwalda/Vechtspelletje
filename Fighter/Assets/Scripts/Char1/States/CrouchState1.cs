using UnityEngine;
using System.Collections;

/*
 * this class represents the crouch state of the character.
 * while in idle or either walking states the character will enter the crouch state if the analogue stick is tilted downwards.
 */

public class CrouchState1 : State1
{

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private StateBasedInputs inputHandler;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip crouchSound;


    public override void Enter()
    {
        anim.SetInteger("AnimState", 6);

        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(crouchSound);
    }

    public override void Act()
    {
    }

    public override void Reason()
    {

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Crouch Up"))
        {
            ReadInputs();
        }
    }

    public override void Leave()
    {   
    }

    void ReadInputs()
    {
        if (inputHandler.AskForLightAttack())
        {
            stateMachine.SetState(StateID.LightSpecial);
        }
        else if (inputHandler.AskForHeavyAttack())
        {
            stateMachine.SetState(StateID.HeavySpecial);
        }
        else if (Input.GetAxis("Vertical") == 0)
        {
            Input.ResetInputAxes();
            stateMachine.SetState(StateID.Idle);
        }
        else if (Input.GetButtonDown("A"))
        {
            stateMachine.SetState(StateID.CrouchLightAttack);
        }
        else if (Input.GetButtonDown("B"))
        {
            //Input.ResetInputAxes();
            stateMachine.SetState(StateID.CrouchHeavyAttack);
        }
        else if (Input.GetAxis("Horizontal") > 0.2f)
        {
            stateMachine.SetState(StateID.WalkForward);
        }
        else if (Input.GetAxis("Horizontal") < -0.2f)
        {
            stateMachine.SetState(StateID.WalkBackward);
        }
    }
}