using UnityEngine;
public class MoveWithVector : MonoBehaviour 
{
	[SerializeField] private Vector3 moveVector;

	// Update is called once per frame
	void Update () 
	{
		transform.Translate(moveVector * Time.deltaTime);
	}
}
