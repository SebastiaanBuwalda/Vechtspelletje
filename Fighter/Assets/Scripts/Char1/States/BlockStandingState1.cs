using UnityEngine;
using System.Collections;

/*
 * this class represents the standing block state.
 * this state is entered from the standing parry state is functions similarly to the crouch variant.
 */

public class BlockStandingState1 : State1 {

    private bool blocking;
    private StateMachine1 stateMachine;
    
    public override void Enter()
    {
        stateMachine = gameObject.GetComponent<StateMachine1>();
        blocking = true;
        StartCoroutine(Block());


    }

    public override void Act()
    {
        if (!Input.GetKey(KeyCode.U))
        {
            blocking = false;
        }
    }

    public override void Reason()
    {
      
    }

    public override void Leave()
    {

    }
    IEnumerator Block()
    {
        while (blocking == true)
        {
            //   Debug.Log("blocking");
            yield return new WaitForEndOfFrame();
            Debug.Log("stay blocking");

        }


            yield return new WaitForEndOfFrame();
            Debug.Log("leave blocking");

            stateMachine.SetState(StateID.Idle);


        
    }
}
