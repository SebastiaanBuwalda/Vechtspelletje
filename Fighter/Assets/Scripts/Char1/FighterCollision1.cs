using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FighterCollision1 : MonoBehaviour {

    [SerializeField]
    private StateMachine1 stateMachine;

    private List<int> noHitstunIdsList = new List<int>();

    void Start()
    {
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
    }

    void Update()
    {
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

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.tag);
    }

}
