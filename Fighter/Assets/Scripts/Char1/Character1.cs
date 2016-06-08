﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID
{
    NullStateID = 0,
    WalkForward = 1,
    WalkBackward = 2,
    Jump = 3,
    Crouch = 4,
    StandParry = 5,
    CrouchParry = 6,
    StandBlock = 7,
    CrouchBlock = 8,
    StandLightAttack = 9,
    StandHeavyAttack = 10,
    CrouchLightAttack = 11,
    CrouchHeavyAttack = 12,
    AirLightAttack = 13,
    AirHeavyAttack = 14,
    DropBlock = 15,
    Hitstun = 16,
    Falling = 17,
    SoftLanding = 18,
    HardLanding = 19,
    LayingDown = 20,
    Idle = 21,
    Getup = 22,
    LightSpecial = 23,
    HeavySpecial = 24,
    JumpForward = 25,
    JumpBackward = 26
}
    

   

public class Character1 : MonoBehaviour {
    private List<int> hittableStates = new List<int>();
    private List<int> ParryAbleStates = new List<int>();



    private StateMachine1 stateMachine;

    void Start()
    {
        
        //change to inspector later
        stateMachine = GetComponent<StateMachine1>();

        MakeStates();

        stateMachine.SetState(StateID.Idle);
    }

    void Update()
    {
        //code to test the onhit function
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnGetHit(2);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartParry();
        }
    }

    void MakeStates()
    {
        //change to smaller function
        //adds the states to the state machine and adds the states where the player is able to be hit to 
        stateMachine.AddState(StateID.Idle, GetComponent<IdleState1>());
        hittableStates.Add((int)StateID.Idle);
        ParryAbleStates.Add((int)StateID.Idle);
        stateMachine.AddState(StateID.WalkForward, GetComponent<WalkForwardState>());
        hittableStates.Add((int)StateID.WalkForward);
        ParryAbleStates.Add((int)StateID.WalkForward);


        stateMachine.AddState(StateID.WalkBackward, GetComponent<WalkBackwardState>());
        hittableStates.Add((int)StateID.WalkBackward);
        ParryAbleStates.Add((int)StateID.WalkBackward);


        stateMachine.AddState(StateID.Jump, GetComponent<JumpState>());
        hittableStates.Add((int)StateID.Jump);

        stateMachine.AddState(StateID.JumpForward, GetComponent<JumpForwardState>());
        hittableStates.Add((int)StateID.JumpForward);
        stateMachine.AddState(StateID.JumpBackward, GetComponent<JumpBackwardState>());
        hittableStates.Add((int)StateID.JumpBackward);

        stateMachine.AddState(StateID.StandParry, GetComponent<ParryStandingState>());
        stateMachine.AddState(StateID.StandBlock, GetComponent<BlockStandingState1>());
        stateMachine.AddState(StateID.CrouchParry, GetComponent<ParryCrouchState>());
        stateMachine.AddState(StateID.CrouchBlock, GetComponent<BlockCrouchState1>());
        stateMachine.AddState(StateID.Crouch, GetComponent<CrouchState1>());
        hittableStates.Add((int)StateID.Crouch);
        ParryAbleStates.Add((int)StateID.WalkForward);


        stateMachine.AddState(StateID.StandLightAttack, GetComponent<StandLightAttackState>());
        hittableStates.Add((int)StateID.StandLightAttack);

        stateMachine.AddState(StateID.StandHeavyAttack, GetComponent<StandHeavyAttackState>());
        hittableStates.Add((int)StateID.StandLightAttack);

        stateMachine.AddState(StateID.CrouchLightAttack, GetComponent<CrouchLightAttackState>());
        hittableStates.Add((int)StateID.CrouchLightAttack);

        stateMachine.AddState(StateID.CrouchHeavyAttack, GetComponent<CrouchHeavyAttackState>());
        hittableStates.Add((int)StateID.CrouchHeavyAttack);

        stateMachine.AddState(StateID.AirLightAttack, GetComponent<AirLightAttack>());
        hittableStates.Add((int)StateID.AirLightAttack);

        stateMachine.AddState(StateID.AirHeavyAttack, GetComponent<AirHeavyAttack>());
        hittableStates.Add((int)StateID.AirHeavyAttack);

        stateMachine.AddState(StateID.DropBlock, GetComponent<BlockDropState>());
        hittableStates.Add((int)StateID.DropBlock);

        stateMachine.AddState(StateID.Hitstun, GetComponent<HitstunState>());
        stateMachine.AddState(StateID.Falling, GetComponent<FallingState>());
        hittableStates.Add((int)StateID.Falling);

        stateMachine.AddState(StateID.SoftLanding, GetComponent<SoftLandingState>());
        hittableStates.Add((int)StateID.SoftLanding);

        stateMachine.AddState(StateID.HardLanding, GetComponent<HardLandingState>());
        hittableStates.Add((int)StateID.HardLanding);

        stateMachine.AddState(StateID.LightSpecial, GetComponent<LightSpecialState>());
        hittableStates.Add((int)StateID.LightSpecial);

        stateMachine.AddState(StateID.HeavySpecial, GetComponent<HeavySpecialState>());
        hittableStates.Add((int)StateID.HeavySpecial);

        stateMachine.AddState(StateID.Getup, GetComponent<GetupState>());

        stateMachine.AddState(StateID.LayingDown, GetComponent<LayingState>());
    }

  //code by Kappert
    //call this function when hit and if the player does not parry the atack
    void OnGetHit(int damage)
    {
        if (hittableStates.Contains(stateMachine.CurrIdInt))
        {
            //call the functions to activate the functions for when you get hit
            stateMachine.SetState(StateID.Hitstun);
            Debug.Log("FLIKKER OP");
        }
    }

    void StartParry()
    {
        //see if the player is currantly able to parry and if so chooses which parry state to switch to
        if (ParryAbleStates.Contains(stateMachine.CurrIdInt)) 
        {
            if (stateMachine.CurrIdInt == (int)StateID.Crouch)
            {
                stateMachine.SetState(StateID.CrouchParry);
            }
            else
            {
                stateMachine.SetState(StateID.StandParry);
            }

            
        }

    }
    //end code by Kappert
}
