using UnityEngine;
using System.Collections;

public class HeavySpecialState2 : State2 {

    [SerializeField]
    private StateMachine2 stateMachine;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float lockTime;
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip fireballSound;
    [SerializeField]
    private PositionBasedFlip positionBasedFlip;

    private bool inState;

    public override void Enter()
    {
        inState = true;
        anim.SetInteger("AnimState", 18);
    }

    public override void Act()
    {

    }

    public override void Reason()
    {
        if (!Input.GetKeyDown(KeyCode.Z))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("H Projectile") && !anim.IsInTransition(0))
            {
                StartCoroutine(LightAtkLockTime());
            }
        }
    }

    public override void Leave()
    {
        inState = false;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("H Projectile"))
        {
            audioSource.PlayOneShot(fireballSound);
            GameObject temp = ObjectPool.instance.GetObjectForType("HadoukenHeavy", false);
            if (positionBasedFlip.FacingLeft)
            {
                temp.gameObject.transform.position = new Vector3(this.transform.position.x - 1, transform.position.y + 1.68f, this.transform.position.z);
                Vector3 hadoukenVector = temp.gameObject.GetComponent<MoveWithVector>().MoveVector;
                temp.gameObject.GetComponent<MoveWithVector>().MoveVector = new Vector3(hadoukenVector.x * -1, hadoukenVector.y, hadoukenVector.z);
            }
            else
            {
                temp.gameObject.transform.position = new Vector3(this.transform.position.x + 1, transform.position.y + 1.68f, this.transform.position.z);
            }
        }
    }

    IEnumerator LightAtkLockTime()
    {
        yield return new WaitForSeconds(lockTime);
        if (inState)
        {
            if (!Input.anyKey)
            {

                stateMachine.SetState(StateID2.Idle);
            }
        }

    }
}
