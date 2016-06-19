using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

    [SerializeField]
    private Image healthBar;

    //add the player health script of each in here through the inspector on the correct health bar
    [SerializeField]
    private PlayerHealth pHealth;

    /*
    [Range(0,1)]
    [SerializeField]
    private float health = 1;
    */
    void Start()
    {
        healthBar.fillAmount = 1;
    }

    void Update()
    {
        //takes a public health float variable that caps at 100 from another class and 
        //applies it to an image fillamount
        
        healthBar.fillAmount = pHealth.GetPlayerHealth * 0.01f;
    }
}
