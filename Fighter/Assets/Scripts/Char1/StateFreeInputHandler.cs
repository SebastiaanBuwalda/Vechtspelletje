﻿using UnityEngine;
using System.Collections;

public class StateFreeInputHandler : MonoBehaviour 
{
	private FightingInput hadouken = new FightingInput(new string[] { "down","right", "A"});
	private FightingInput hadoukenHeavy = new FightingInput(new string[] { "down","right", "B"});

	private FightingInput hadoukenL = new FightingInput(new string[] { "down","left", "A"});
	private FightingInput hadoukenHeavyL = new FightingInput(new string[] { "down","left", "B"});

	[SerializeField]
	private PositionBasedFlip positionBasedFlip;
	public bool returnHadouken()
	{
		if (!positionBasedFlip.FacingLeft) 
			{
			if (hadouken.GetInput ()) 
			{
				return true;
			} 
			else  
			{
				return false;
			}
		} 
		else if (positionBasedFlip.FacingLeft)
		{
			if (hadoukenL.GetInput ()) 
			{
				Debug.Log ("hal");
				return true;
			}
			else 
			{
				return false;
			}
		}
		return false;
	}

	public bool returnHadoukenHeavy()
	{
		if (positionBasedFlip.FacingLeft==false) 
		{
			if (hadoukenHeavy.GetInput ()) {
				return true;
			} else {
				return false;
			}
		} 
		if (positionBasedFlip.FacingLeft==true)
		{
			if (hadoukenHeavyL.GetInput ()) {
				return true;
			} else {
				return false;
			}
		}
		return false;

	}
}
