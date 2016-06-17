using UnityEngine;
using System.Collections;

public class ActivateLoadscreen : MonoBehaviour {

    [SerializeField]
    private GameObject loadScreen;

    public void LoadscreenActivate()
    {
        loadScreen.SetActive(true);
    }
}
