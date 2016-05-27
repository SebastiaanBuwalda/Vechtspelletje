using UnityEngine;
using System.Collections;

public class StateMachineExplanation : MonoBehaviour {

	/*
     * de statemachine werkt alleen als alle states die in de character class (Char1/Char2) in de StateID enum wordt gedaan als component op het object zitten.
     * in de StateID enum worden alle states die de statemachine gebruikt bij elkaar gezet.
     */

    //voor char 1
    public enum StateIDs
    {
        NullStateID = 0,
        WalkForward = 1,
        WalkBackward = 2,
        Jump = 3,
        //etc.
    }
    //voor char 2 heeft deze enum de naam StateID2. dit is omdat wij twee statemachines gebruiken voor beide karakters en als deze enums dezelfde naam zouden hebben gaat ie stuk.

    //eenmaal in states kan je naar een andere state switchen door de SetState functie te gebruiken.

    private StateMachine1 stateMachine; //voor char 1, voor char 2 moet het datatype StateMachine2 zijn
    void Start()
    {
        stateMachine = GetComponent<StateMachine1>(); //kan ook via inspector

        stateMachine.SetState(StateID.WalkForward/*state naam uit de StateID enum*/);
    }

    //als je van state switched worden alle bezigheden die niet in de functies van monobehaviour bezig zijn onderbroken. Start, Update, FixedUpdate gaan dus gewoon door.
    //om problemen hiermee te voorkomen gebruiken we de 

    //public override void Enter(){}    werkt als start functie, word aangeroepen wanneer je naar de state switched
    //public override void Act(){}      werkt als Update functie, word elke frame aangeroepen en stopt wanneer je naar een andere state switched
    //public override void Reason(){}   werkt hetzelfde als de Act() functie maar word eerder aangeroepen
    //public override void Leave(){}    deze functie word aangeroepen wanneer je naar een andere state switched
    //functies
}
