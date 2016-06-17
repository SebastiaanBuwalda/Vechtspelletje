using UnityEngine;
using System.Collections;

public class PositionBasedFlip : MonoBehaviour {

	[SerializeField]
	private Transform player2Transform;

	public bool facingLeft = false;

	void Update()
	{
		if (facingLeft) 
		{
			if (this.transform.position.x < player2Transform.position.x) 
			{
				Flip ();
			}
		} 
		else 
		{
			if (this.transform.position.x > player2Transform.position.x) 
			{
				Flip ();
			}
		}
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

	public bool FacingLeft 
	{
		get 
		{
			return facingLeft;
		}
	}
}
