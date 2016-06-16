using UnityEngine;
using System.Collections;

public class TimerCountdown : MonoBehaviour 
{
	public int timer = 99;

	[SerializeField]
	private DrawTimer drawTimer;


	void Start () 
	{
		StartCoroutine (Countdown ());
	}


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
