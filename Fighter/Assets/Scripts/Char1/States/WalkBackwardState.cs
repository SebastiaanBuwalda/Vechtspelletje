using UnityEngine;
using System.Collections;

/*
 * this class represents the character walking backwards.
 * this state is entered from the idle and walking forward states when the analogue stick is tilted away from the opponent.
 */

public class WalkBackwardState : State1 {

    [SerializeField] private StateMachine1 stateMachine;
    [SerializeField] private Animator anim;
    [SerializeField] private Vector3 moveVector;

    void Start()
    {
        //stateMachine = GetComponent<StateMachine1>();
    }

    public override void Enter()
    {
        //Debug.Log("Walk backwards state");
        anim.SetInteger("AnimState", 1);
    }

    public override void Act()
    {
        transform.Translate(moveVector * Time.deltaTime);
        //transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);
    }

    public override void Reason()
    {
        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            stateMachine.SetState(StateID.Idle);
        }else if(!Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            stateMachine.SetState(StateID.WalkForward);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            stateMachine.SetState(StateID.JumpBackward);
        }
    }

    public override void Leave()
    {
        
    }
}
