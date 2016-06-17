using UnityEngine;
using System.Collections;

public class FlickeringLIght : MonoBehaviour {
	[SerializeField]
	private Light light;

	[SerializeField]
	private float duration = 1.0F;

	[SerializeField]
	private float brightnessValue = 0.5F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float phi = Time.time / duration * 2 * Mathf.PI;
		float amplitude = Mathf.Cos (phi) * brightnessValue + brightnessValue;
		light.intensity = amplitude;	
	}
}
