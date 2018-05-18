using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {
    //variables for the enemies health
    public float maxHealth;
    float currentHealth;
    //variable for the particle system
    public GameObject enemyDeathFX;
    //variable for the enemy slider
    public Slider enemySlider;
    public bool canDrop;
    public GameObject healthPack;
    public AudioClip enemyDeathSound;
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        //set the max health for the enemy
        enemySlider.maxValue = maxHealth;
        //set the current health of the enemy
        enemySlider.value = currentHealth;
        //make sure that the enemy health bar is not visible until you hit it
        enemySlider.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void enemyHit(float damage)
    {
        //when you hit the enemy we want to see its health
        enemySlider.gameObject.SetActive(true);
        //reduce the health of the enemy
        currentHealth -= damage;
        enemySlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            //destroy the enemy
            makeDead();
        }
    }
    void makeDead()
    {
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
        Destroy(gameObject.transform.parent.gameObject);
        //instatiate the enemy death particle system in our current position
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (canDrop)
        {
            Instantiate(healthPack, transform.position, transform.rotation);
        }
    }
}
