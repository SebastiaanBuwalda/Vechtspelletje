using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	[SerializeField]
	private float destroySeconds;

	void OnEnable()
	{
		StartCoroutine (DestroyTimer ());
	}

	IEnumerator DestroyTimer()
	{
		yield return new WaitForSeconds (destroySeconds);
		Destroy (gameObject);
	}
}
