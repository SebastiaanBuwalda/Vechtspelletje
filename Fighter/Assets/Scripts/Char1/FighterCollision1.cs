using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FighterCollision1 : MonoBehaviour {

    [SerializeField]
    private StateMachine1 stateMachine;

    private List<int> noHitstunIdsList = new List<int>();

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        FillIdList();
    }

    void FillIdList()
    {
        noHitstunIdsList.Add(3);
        noHitstunIdsList.Add(5);
        noHitstunIdsList.Add(6);
        noHitstunIdsList.Add(7);
        noHitstunIdsList.Add(8);
        noHitstunIdsList.Add(13);
        noHitstunIdsList.Add(14);
        noHitstunIdsList.Add(17);
        noHitstunIdsList.Add(19);
        noHitstunIdsList.Add(22);
        noHitstunIdsList.Add(25);
        noHitstunIdsList.Add(26);

        for (int i = 0; i < noHitstunIdsList.Capacity; i++)
        {
            Debug.Log(noHitstunIdsList[i]);
            if(stateMachine.CurrIdInt == i)
            {
                //dont take damage from any attacks you get hit by
            }
        }
    }

    void Update()
    {
        //this class may or may not be neccesary. As of right now im not sure what to do
        //with it, i guess i was thinking of a global character collision class that would
        //receive calls from the states when the character was hit in that state and then
        //work out if damage should be received and if the character should enter hitstun
        //or falling or something like that.


        //check Character class StateID enum for state IDs
        //Debug.Log(stateMachine.CurrIdInt);

        //check in what states the player can't be brought into hitstun
        //3 jumps           ids     3, 25, 26
        //2 parrys          ids     5, 6
        //2 blocks          ids     7, 8
        //2 air attacks     ids     13, 14
        //falling           id      17
        //hard landing      id      19
        //getup             id      22
        //check if statemachine is in any of these states
    }

    void OnMouseDown()
    {
        playerHealth.ChangeHealth(20);
        stateMachine.SetState(StateID.Hitstun);
    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.tag);
    }

}
