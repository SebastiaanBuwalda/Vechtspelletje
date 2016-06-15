using UnityEngine;
public class MoveWithVector : MonoBehaviour 
{
	[SerializeField] private Vector3 moveVector;
	private Vector3 trueVector;


	void Awake()
	{
		trueVector = moveVector;
	}

	void OnDisable()
	{
		moveVector = trueVector;
	}


	// Update is called once per frame
	void Update () 
	{
		transform.Translate(moveVector * Time.deltaTime);
	}

	public Vector3 MoveVector
	{
		get
		{
			return moveVector;
		}
		set
		{
			moveVector = value;
		}
	}
}
