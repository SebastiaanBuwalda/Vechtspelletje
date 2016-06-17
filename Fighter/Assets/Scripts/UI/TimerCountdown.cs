using UnityEngine;
using System.Collections;

public class TimerCountdown : MonoBehaviour 
{
	public int timer = 99;

	[SerializeField]
	private DrawTimer drawTimer;

	private bool activated = false;

	IEnumerator Countdown()
	{
		yield return new WaitForSeconds (1);
		if (timer > 0) {
			timer--;
			drawTimer.UpdateUI ();
			StartCoroutine (Countdown ());
		}
	}

	void LateUpdate()
	{
		if (PreMatchCountdown.canMove&&!activated) 
		{
			StartCoroutine (Countdown ());
			activated = true;
		}
		if (timer <= 0) 
		{
			//Game over
		}
	}

	public int Timer()
	{
		return timer;
	}
}
