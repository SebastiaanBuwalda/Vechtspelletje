using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IHealth {
    private int _playerHealth;

    void Awake()
    {
        _playerHealth = 100;
    }

    //code for testing purposes 

    public void ChangeHealth(int damage)
    {
        //this functions should be called from a delegate
        _playerHealth -= damage;
        Debug.Log("current Health" + _playerHealth);
    }

    public void OnDeath()
    {
        //run the code for when the health hits zero, should be triggered from delegate
        Debug.Log("other player wins");
    }
  

}
