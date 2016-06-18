using UnityEngine;
using System.Collections;

public class collisionDetection : MonoBehaviour {

	void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.tag);
    }
}
