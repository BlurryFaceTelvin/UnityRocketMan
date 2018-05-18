using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDoor : MonoBehaviour {

    bool activated;
    //portal position
    public Transform portalLocation;
    //portal reference
    public GameObject portal;

	// Use this for initialization
	void Start () {
        activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player has entered out region
        if (collision.tag == "Player"&&!activated)
        {
            activated = true;
            Instantiate(portal, portalLocation.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }   
    
}
