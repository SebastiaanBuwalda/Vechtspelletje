using UnityEngine;
using System.Collections;

/*
 * this class represents the standing light attack state.
 * this state is entered when the character is in his idle state and the light attack button is pressed.
 */

public class StandLightAttackState : State1 {

    [SerializeField]
    private StateMachine1 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float lockTime;

    private bool inState;

    [SerializeField]
    private GameObject hitBox;


    public override void Enter()
    {
        inState = true;
        anim.SetInteger("AnimState", 3);
        Input.ResetInputAxes();
    }

    public override void Act()
    {

    }

    public override void Reason()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("L punch") && !anim.IsInTransition(0))
        {
            StartCoroutine(LightAtkLockTime());
        }
    }

    public override void Leave()
    {
        inState = false;   
    }

    void ActivateLightHitbox()
    {
        //this method is called via animation event
        hitBox.SetActive(true);
    }

    void DeactivateLightHitbox()
    {
        //this method is called via animation event
        hitBox.SetActive(false);
    }

    //time untill player can move again
    IEnumerator LightAtkLockTime()
    {
        yield return new WaitForSeconds(lockTime);
        if(inState)
        {
            if (!Input.anyKey || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space))
                stateMachine.SetState(StateID.Idle);
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                stateMachine.SetState(StateID.WalkBackward);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                stateMachine.SetState(StateID.WalkForward);
            }
        }
    }
}
