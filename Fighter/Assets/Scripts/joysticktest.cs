using UnityEngine;
using System.Collections;

public class joysticktest : MonoBehaviour {
	[SerializeField]
	string[] joy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		joy = Input.GetJoystickNames ();
	}
}
