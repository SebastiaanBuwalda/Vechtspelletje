using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour, IHealth {
    private float _playerHealth;
    public float GetPlayerHealth
    {
        get { return _playerHealth; }
    }

    [SerializeField]
    private AudioSource hitsound;
    private AudioClip clip1;
    [SerializeField]
    private List<AudioClip> clipList = new List<AudioClip>();

    void Awake()
    {
        _playerHealth = 100;
    }


    //code for testing purposes 
    
    public void ChangeHealth(float damage)
    {
        
        //hitsound.PlayOneShot(clipList[getRandomClip(clipList)]);
        //this functions should be called from a delegate
        _playerHealth -= damage;
        Debug.Log("current Health" + _playerHealth);
    }

    public void OnDeath()
    {
        //run the code for when the health hits zero
        Debug.Log("other player wins");
    }
  
    int getRandomClip(List<AudioClip> clips)
    {
        return Random.Range(0, clips.Count);
    }
}
