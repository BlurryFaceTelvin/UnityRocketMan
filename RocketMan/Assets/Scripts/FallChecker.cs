using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallChecker : MonoBehaviour {
    //reference to playerHealth class
    PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make sure we are colliding with player
        if(collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<PlayerHealth>();
            playerHealth.makeDead();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
