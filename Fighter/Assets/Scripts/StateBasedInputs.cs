using UnityEngine;
using System.Collections;

public class StateBasedInputs : MonoBehaviour 
{
	private int statePlace = 0;

	[SerializeField]
	private float allowedTimeBetweenButtons = 0.5f;

	[SerializeField]
	private PositionBasedFlip positionBasedFlip;

	[SerializeField]
	private string verticalString = "Vertical";

	[SerializeField] 
	private string horizontalString = "Horizontal";

	[SerializeField]
	private string aString = "A";

	[SerializeField]
	private string bString = "B";

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
		if (Input.GetAxis (verticalString) < 0) 
		{
			statePlace = 1;
			StartCoroutine (inputReset (1));
		}
	}

	void AskForForward()
	{
		if (!positionBasedFlip.FacingLeft) {
			if (Input.GetAxis (horizontalString) > 0) {
				statePlace = 2;
				StartCoroutine (inputReset (2));
			}
		} else if (positionBasedFlip.FacingLeft) {
			if (Input.GetAxis (horizontalString) < 0) {
				statePlace = 2;
				StartCoroutine (inputReset (2));
			}
		}

	}

	public bool AskForLightAttack()
	{
		if (Input.GetButtonDown (aString)&&statePlace==2) {
			return true;
			statePlace = 0;
		} else
			return false;
	}

	public bool AskForHeavyAttack()
	{
		if (Input.GetButtonDown (bString)&&statePlace==2) 
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
