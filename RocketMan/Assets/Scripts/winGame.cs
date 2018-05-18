using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winGame : MonoBehaviour {
    //referece to playerhealth
    PlayerHealth playerWins;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //initialise the playerhealth
        playerWins = collision.gameObject.GetComponent<PlayerHealth>();
        //check whether the player has interacted with the win object
        if (collision.tag == "Player")
        {
            //player wins
            playerWins.winGame();
        }
    }
}
