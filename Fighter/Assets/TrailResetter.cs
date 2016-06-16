using UnityEngine;
using System.Collections;

public class TrailResetter : MonoBehaviour {

    private TrailRenderer trailRender;

    void Start()
    {
        trailRender = GetComponentInChildren<TrailRenderer>();
    }

    void OnDisable()
    {
        trailRender.Clear();
    }
}
