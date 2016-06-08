 using UnityEngine;
using System.Collections;

public class StateFreeInputHandler : MonoBehaviour 
{
	private FightingInput hadouken = new FightingInput(new string[] { "down","right", "Fire1"});
	private FightingInput hadoukenHeavy = new FightingInput(new string[] { "down","right", "Fire2"});

	private FightingInput hadoukenL = new FightingInput(new string[] { "down","left", "Fire1"});
	private FightingInput hadoukenHeavyL = new FightingInput(new string[] { "down","left", "Fire2"});

	[SerializeField]
	private PositionBasedFlip positionBasedFlip;


	void Awake()
	{
		print (positionBasedFlip.FacingLeft);
	}

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
		else 
		{
			if (hadoukenL.GetInput ()) 
			{
				return true;
			}
			else 
			{
				return false;
			}
		}
	}


	

	public bool returnHadoukenHeavy()
	{
		if (!positionBasedFlip.FacingLeft) {
			if (hadoukenHeavy.GetInput ()) {
				return true;
			} else {
				return false;
			}
		} 
		else 
		{
			if (hadoukenHeavyL.GetInput ()) {
				return true;
			} else {
				return false;
			}
		}
	}
}
