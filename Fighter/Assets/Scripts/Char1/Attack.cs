using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("trigger with " + coll);
    }
}
