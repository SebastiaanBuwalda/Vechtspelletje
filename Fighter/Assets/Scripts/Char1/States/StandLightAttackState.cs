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

    [SerializeField]
    private GameObject hitBox;


    public override void Enter()
    {
        anim.SetInteger("AnimState", 3);
    }

    public override void Act()
    {

    }

    public override void Reason()
    {
        if(!Input.GetKeyDown(KeyCode.Z))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("L punch"))
            {
                StartCoroutine(LightAtkLockTime());
            }
        }
    }

    public override void Leave()
    {
        
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
        if(!Input.anyKey)
            stateMachine.SetState(StateID.Idle);
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            stateMachine.SetState(StateID.WalkBackward);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            stateMachine.SetState(StateID.WalkForward);
        }
    }
}
