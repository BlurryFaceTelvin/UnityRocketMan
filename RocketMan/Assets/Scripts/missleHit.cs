using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missleHit : MonoBehaviour {
    //variable for damage
    public float missleDamage;
    //reference of the projectile Controller
    projectileController myPC;
    public GameObject explosionObject;
    

	// Use this for initialization
	void Awake () {
        myPC = GetComponentInParent<projectileController>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if our missle collider collides with a collider of an enemy
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            //stop the missle
            myPC.removeForce();
            //instatiate the explosion
            Instantiate(explosionObject, transform.position, transform.rotation);
            Destroy(gameObject);
            //check if the game object hit is an enemy
            if (collision.tag== "Enemy")
            {
                //reference to the enemyHealth
                enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
                if (hurtEnemy != null)
                {
                    hurtEnemy.enemyHit(missleDamage);
                }
                else
                {
                    Debug.Log("Null object reference");
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if our missle collider collides with a collider of an enemy
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            //stop the missle
            myPC.removeForce();
            //instatiate the explosion
            Instantiate(explosionObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        //check if the game object hit is an enemy
        if (collision.tag == "Enemy")
        {
            //reference to the enemyHealth
            enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
            if (hurtEnemy != null)
            {
                hurtEnemy.enemyHit(missleDamage);
            }
            else
            {
                Debug.Log("Null object reference");
            }
        }
    }
}
