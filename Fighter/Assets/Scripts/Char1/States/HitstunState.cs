using UnityEngine;
using System.Collections;

/*
 * this class represents hitstun. this state is entered when the character is hit by a heavy or light attack while in idle and also by a light attack while already in hitstun.
 * after a set few frames the character enters the parry state.
 */

public class HitstunState : State1 {

    //delegate to loosly couple the clasess and still take damage
    private delegate int DamageTaker();
    private DamageTaker damageTaker;
    private Renderer rend;

    //time variable to determine the time the player stays in the histstun state
    private float stunTimer;
    [SerializeField]
    private StateMachine1 stateMachine;
    private bool inState;
    private bool OnGround;
    private Rigidbody rb;

    private IHealth playerHealh;
    public override void Enter()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        stateMachine = gameObject.GetComponent<StateMachine1>();
        base.Enter();
        //test code to see if the state works
        stunTimer = DetermineStunTime("Light");
        StartCoroutine(StayTimer(stunTimer));
        playerHealh = gameObject.GetComponent<IHealth>();

        inState = true;
    }

    public override void Act()
    {
      //  Debug.Log("stunning");

    }
    public override void Reason()
    {

    }

    void OnCollisionEnter(Collision collision)
    {       
        Debug.Log("enter");
        OnGround = true;   
        
    }
    void OnCollisionExit(Collision collision)
    {
        OnGround = false;
        Debug.Log("exit");

    }
    public override void Leave()
    {
        inState = false;
    }

    IEnumerator StayTimer(float stayTime)
    {
        yield return new WaitForSeconds(stayTime / 2);
        rb.isKinematic = true;
        yield return new WaitForSeconds(stayTime);
        playerHealh.ChangeHealth(1);

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

    private float DetermineStunTime(string atack)
    {
        if (atack == "Heavy")
        {
            return 0.5f;
        }
        else
        {
            return 0.2f;
        }
    }
}
