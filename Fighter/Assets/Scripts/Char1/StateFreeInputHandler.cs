 using UnityEngine;
using System.Collections;

public class StateFreeInputHandler : MonoBehaviour 
{
	private FightingInput hadouken = new FightingInput(new string[] { "down","right", "Fire1"});
	private FightingInput hadoukenHeavy = new FightingInput(new string[] { "down","right", "Fire2"});

	public bool returnHadouken()
	{
		if (hadouken.GetInput ()) {
			return true;
		} else {
			return false;
		}
	}

	public bool returnHadoukenHeavy()
	{
		if (hadoukenHeavy.GetInput ()) {
			return true;
		} else {
			return false;
		}
	}
}
