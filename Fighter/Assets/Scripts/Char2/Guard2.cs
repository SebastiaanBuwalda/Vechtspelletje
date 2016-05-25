using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StateID2
{
	NullStateID2 = 0,
	Wandering2 = 1,
	Alerting2 = 2,
	Fleeing2 = 3
}

public class Guard2 : MonoBehaviour {

	/** we declareren de statemachine */
	private StateMachine2 stateMachine;

	// Use this for initialization
	void Start () {
		/** we halen een referentie op naar de state machine */
		stateMachine = GetComponent<StateMachine2>();

		/** we voegen de verschillende states toe aan de state machine */
		MakeStates();

		/** we geven de eerste state door (rondlopen) */
		stateMachine.SetState( StateID2.Wandering2 );
	}
	
	void MakeStates() {
        /*
		stateMachine.AddState( StateID2.Alerting2, GetComponent<AlertState2>() );
		stateMachine.AddState( StateID2.Wandering2, GetComponent<WanderState2>() );
		stateMachine.AddState( StateID2.Fleeing2, GetComponent<FleeState2>() );
         */

        Debug.Log("Made States and Got Components");
	}

}