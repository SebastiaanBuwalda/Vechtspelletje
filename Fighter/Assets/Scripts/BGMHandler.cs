using UnityEngine;
using System.Collections;

public class BGMHandler : MonoBehaviour {

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip musicIntro;
    [SerializeField]
    private AudioClip musicLoop;

    void Start()
    {
        audioSource.PlayOneShot(musicIntro);
    }

    void Update()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(musicLoop);
    }
}
