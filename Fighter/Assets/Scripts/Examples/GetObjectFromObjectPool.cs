using UnityEngine;
public class GetObjectFromObjectPool 
{
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Use this line to get an object from the object pool.
			ObjectPool.instance.GetObjectForType ("Gameobject name goes here", true);
		}
	}
}