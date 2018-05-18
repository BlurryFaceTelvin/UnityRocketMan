using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour {
    public float missleForce;
    //reference to the rigidbody
    Rigidbody2D myRB;
	// Use this for initialization
	void Awake () {
        myRB = GetComponent<Rigidbody2D>();
        //move the missle in the x position with a force
        //check to see which direction characeter is facing and move the character accordingly
        if (transform.localRotation.z > 0)
        {
            //facing left
            myRB.AddForce(new Vector2(-1, 0) * missleForce, ForceMode2D.Impulse);
        }
        else
        {
            //facing right
            myRB.AddForce(new Vector2(1, 0) * missleForce, ForceMode2D.Impulse);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void removeForce()
    {
        //stop movement
        myRB.velocity = new Vector2(0, 0);
    }
}
