using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID2
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

public class Character2 : MonoBehaviour {

    private StateMachine2 stateMachine;

    private Input input;

    void Start()
    {
        //change to inspector later
        stateMachine = GetComponent<StateMachine2>();

        MakeStates();

        stateMachine.SetState(StateID2.Idle);
    }

    void MakeStates()
    {
        stateMachine.AddState(StateID2.Idle, GetComponent<IdleState2>());
        stateMachine.AddState(StateID2.WalkForward, GetComponent<WalkForwardState2>());
        stateMachine.AddState(StateID2.WalkBackward, GetComponent<WalkBackwardState2>());
        stateMachine.AddState(StateID2.Jump, GetComponent<JumpState2>());
        stateMachine.AddState(StateID2.JumpForward, GetComponent<JumpForwardState2>());
        stateMachine.AddState(StateID2.JumpBackward, GetComponent<JumpBackwardState2>());
        stateMachine.AddState(StateID2.StandParry, GetComponent<ParryStandingState2>());
        stateMachine.AddState(StateID2.StandBlock, GetComponent<BlockStandingState2>());
        stateMachine.AddState(StateID2.CrouchParry, GetComponent<ParryCrouchState2>());
        stateMachine.AddState(StateID2.CrouchBlock, GetComponent<BlockCrouchState2>());
        stateMachine.AddState(StateID2.Crouch, GetComponent<CrouchState2>());
        stateMachine.AddState(StateID2.StandLightAttack, GetComponent<StandLightAttackState2>());
        stateMachine.AddState(StateID2.StandHeavyAttack, GetComponent<StandHeavyAttackState2>());
        stateMachine.AddState(StateID2.CrouchLightAttack, GetComponent<CrouchLightAttack2>());
        stateMachine.AddState(StateID2.CrouchHeavyAttack, GetComponent<CrouchHeavyAttack2>());
        stateMachine.AddState(StateID2.AirLightAttack, GetComponent<AirLightAttack2>());
        stateMachine.AddState(StateID2.AirHeavyAttack, GetComponent<AirHeavyAttack2>());
        stateMachine.AddState(StateID2.DropBlock, GetComponent<BlockDropState2>());
        stateMachine.AddState(StateID2.Hitstun, GetComponent<HitstunState2>());
        stateMachine.AddState(StateID2.Falling, GetComponent<FallingState2>());
        stateMachine.AddState(StateID2.SoftLanding, GetComponent<SoftLandingState2>());
        stateMachine.AddState(StateID2.HardLanding, GetComponent<HardLandingState2>());
        stateMachine.AddState(StateID2.LightSpecial, GetComponent<LightSpecialState2>());
        stateMachine.AddState(StateID2.HeavySpecial, GetComponent<HeavySpecialState2>());
        stateMachine.AddState(StateID2.Getup, GetComponent<GetupState2>());
        stateMachine.AddState(StateID2.LayingDown, GetComponent<LayingState2>());
    }
}
