using UnityEngine;
using System.Collections;

public class StateBasedInputs : MonoBehaviour 
{
	private int statePlace = 0;

	[SerializeField]
	private float allowedTimeBetweenButtons = 0.5f;

	[SerializeField]
	private PositionBasedFlip positionBasedFlip;

	void Update()
	{
		if (statePlace == 0)
			AskForDown ();
		if (statePlace == 1)
			AskForForward ();
		if (statePlace == 2) 
		{
			AskForLightAttack ();
			AskForHeavyAttack ();
		}
		
	}

	void AskForDown()
	{
		if (Input.GetAxis ("Vertical2") < 0) 
		{
			statePlace = 1;
			StartCoroutine (inputReset (1));
		}
	}

	void AskForForward()
	{
		if (!positionBasedFlip.FacingLeft) {
			if (Input.GetAxis ("Horizontal2") > 0) {
				statePlace = 2;
				StartCoroutine (inputReset (2));
			}
		} else if (positionBasedFlip.FacingLeft) {
			if (Input.GetAxis ("Horizontal2") < 0) {
				statePlace = 2;
				StartCoroutine (inputReset (2));
			}
		}

	}

	public bool AskForLightAttack()
	{
		if (Input.GetButtonDown ("A")&&statePlace==2) {
			return true;
			statePlace = 0;
		} else
			return false;
	}

	public bool AskForHeavyAttack()
	{
		if (Input.GetButtonDown ("B")&&statePlace==2) 
		{
			return true;
			statePlace = 0;
		} else
			return false;
	}

	IEnumerator inputReset(int resetInt)
	{
		yield return new WaitForSeconds (allowedTimeBetweenButtons);
		if (statePlace == resetInt) 
		{
			statePlace = 0;
		}
	}
}
