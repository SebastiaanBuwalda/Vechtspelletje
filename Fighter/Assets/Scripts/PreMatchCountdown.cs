using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PreMatchCountdown : MonoBehaviour 
{
	public static bool canMove = false;

	[SerializeField]
	private Text startText;

	// Use this for initialization
	void Start () 
	{
		canMove = false;
		StartCoroutine (CountDown ());
	}

	IEnumerator CountDown()
	{
		startText.text = "Ready?";
		yield return new WaitForSeconds (1);
		startText.text = "Fight!";
		yield return new WaitForSeconds (1);
		startText.text = "";
		canMove = true;
	}
		


}
