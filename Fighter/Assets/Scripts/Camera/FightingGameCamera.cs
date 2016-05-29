using UnityEngine;
[RequireComponent (typeof (Camera))]
public class FightingGameCamera : MonoBehaviour 
{
	[SerializeField]
	private float minFOV = 40;
	[SerializeField]
	private float maxFOV = 60;

	[SerializeField]
	private float cameraHeight;

	[SerializeField]
	private Transform player1Transform;
	[SerializeField]
	private Transform player2Transform;

	[SerializeField]
	private float FOVMultiplier = 8;

	[SerializeField]
	private Camera mainCamera;

	void LateUpdate () 
	{
		//Make sure the camera is in the middle of the players
		this.transform.position = new Vector3 ((player1Transform.position.x + player2Transform.position.x)/2, cameraHeight, this.transform.position.z);
		//Calculate the delta between the two positions
		float _FOV = FOVMultiplier*(player1Transform.position.x - player2Transform.position.x);;
		if (_FOV < 0) 
		{
			//Make sure the FOV never goes negative, so it will always return the delta
			_FOV = _FOV * -1;
		}
		//Keep the FOV between the designated bounds
		_FOV = Mathf.Clamp (_FOV, minFOV, maxFOV);
		mainCamera.fieldOfView = _FOV;
	}
}
