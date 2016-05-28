using UnityEngine;
using System.Collections;

public class FightingInputExample 
{
	//Don't use this this class in the final game, but use this as a reference for how to use this dataclass.
	private FightingInput hadouken = new FightingInput(new string[] { "down","right", "Fire1"});
	void Update ()
	{
		if (hadouken.GetInput())
		{
			Debug.Log("Hadouken!");
		}
	}
}
