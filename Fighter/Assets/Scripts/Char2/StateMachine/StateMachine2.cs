﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine2 : MonoBehaviour {

	/// <summary>
	/// Deze finite state machine kan makkelijk hergebruikt worden in verschillende projecten
	/// Aangezien hij niet gekoppeld is aan specifieke details (namen van Classes, etc.) van dit project
	/// Enige minpunt is dat hij MonoBehaviour extend
	/// </summary>

	/** We maken een dictionary aan om de states in bij te houden */
	private Dictionary<StateID2, State2> states = new Dictionary<StateID2, State2> ();

	/** een verwijzing naar de huidige staat waarin we verkeren */
	private State2 currentState;
	
	void Update () {
		// als we een state hebben: uitvoeren die hap
		if(currentState != null){
			currentState.Reason();
			currentState.Act();
		}
		
	}

	/// <summary>
	/// Method om de state te wijzigen
	/// </summary>
	public void SetState(StateID2 stateID) {

		/** als we de stateID niet kennen als state: stop deze functie dan */
		if(!states.ContainsKey(stateID))
			return;

		/** als we ons al in een state bevinden: geef de state de mogelijkheid zich op te ruimen */
		if(currentState != null)
			currentState.Leave();

		/** we stellen de nieuwe currentState in */
		currentState = states[stateID];

		/** we geven de nieuwe state de mogelijkheid om zich zelf in te stellen */
		currentState.Enter();
	}

	/// <summary>
	/// Voeg een state toe aan de state machine
	/// LET OP! Alle components die de Class State.cs extenden (inheritance) die mogen in de Dictionary
	/// Daarom mogen AlertState.cs, AlertState.cs en FleeState.cs in de dictionary, aangezien zij State.CS extenden
	/// </summary>
	/// <param name="stateID">Een integer die komt uit de ENUM StateID (zie StateID in Guard.cs)</param>
	/// <param name="state">Een component die State.cs extend (inheritance)</param>
	public void AddState(StateID2 stateID, State2 state) {
		states.Add( stateID, state );
	}

}
