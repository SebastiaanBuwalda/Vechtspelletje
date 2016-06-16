using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrawTimer : MonoBehaviour 
{
[SerializeField]
private TimerCountdown timerCountdown; 
[SerializeField]
private Text timerText;

	void Start()
	{
		UpdateUI ();
	}

	public void UpdateUI()
	{
		timerText.text = "" + timerCountdown.timer;
	}

}
