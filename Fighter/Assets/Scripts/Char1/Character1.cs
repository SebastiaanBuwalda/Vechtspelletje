using UnityEngine;
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

    private StateMachine1 stateMachine;

    void Start()
    {
        //change to inspector later
        stateMachine = GetComponent<StateMachine1>();

        MakeStates();

        stateMachine.SetState(StateID.Idle);
    }

    void MakeStates()
    {
        stateMachine.AddState(StateID.Idle, GetComponent<IdleState1>());
        stateMachine.AddState(StateID.WalkForward, GetComponent<WalkForwardState>());
        stateMachine.AddState(StateID.WalkBackward, GetComponent<WalkBackwardState>());
        stateMachine.AddState(StateID.Jump, GetComponent<JumpState>());
        stateMachine.AddState(StateID.JumpForward, GetComponent<JumpForwardState>());
        stateMachine.AddState(StateID.JumpBackward, GetComponent<JumpBackwardState>());
        stateMachine.AddState(StateID.StandParry, GetComponent<ParryStandingState>());
        stateMachine.AddState(StateID.StandBlock, GetComponent<BlockStandingState1>());
        stateMachine.AddState(StateID.CrouchParry, GetComponent<ParryCrouchState>());
        stateMachine.AddState(StateID.CrouchBlock, GetComponent<BlockCrouchState1>());
        stateMachine.AddState(StateID.Crouch, GetComponent<CrouchState1>());
        stateMachine.AddState(StateID.StandLightAttack, GetComponent<StandLightAttackState>());
        stateMachine.AddState(StateID.StandHeavyAttack, GetComponent<StandHeavyAttackState>());
        stateMachine.AddState(StateID.CrouchLightAttack, GetComponent<CrouchLightAttackState>());
        stateMachine.AddState(StateID.CrouchHeavyAttack, GetComponent<CrouchHeavyAttackState>());
        stateMachine.AddState(StateID.AirLightAttack, GetComponent<AirLightAttack>());
        stateMachine.AddState(StateID.AirHeavyAttack, GetComponent<AirHeavyAttack>());
        stateMachine.AddState(StateID.DropBlock, GetComponent<BlockDropState>());
        stateMachine.AddState(StateID.Hitstun, GetComponent<HitstunState>());
        stateMachine.AddState(StateID.Falling, GetComponent<FallingState>());
        stateMachine.AddState(StateID.SoftLanding, GetComponent<SoftLandingState>());
        stateMachine.AddState(StateID.HardLanding, GetComponent<HardLandingState>());
        stateMachine.AddState(StateID.LightSpecial, GetComponent<LightSpecialState>());
        stateMachine.AddState(StateID.HeavySpecial, GetComponent<HeavySpecialState>());
        stateMachine.AddState(StateID.Getup, GetComponent<GetupState>());
        stateMachine.AddState(StateID.LayingDown, GetComponent<LayingState>());

        Debug.Log("Made States, got components");
    }
}
