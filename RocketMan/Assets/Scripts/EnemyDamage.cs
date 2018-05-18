using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    //variable for the damage and damageRate
    public float damage, damageRate;
    //push back force
    public float pushbackForce;
    //next damage
    float nextDamage;
	// Use this for initialization
	void Start () {
        nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        //check if the player collides with our object
        if(collision.tag=="Player" && nextDamage < Time.time)
        {
            //reference to the playerHealth class
            PlayerHealth myPlayerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            myPlayerHealth.playerHit(damage);
            nextDamage = Time.time + damageRate;

            //push back the character in a certain direction
            pushBack(collision.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushbackForce;
        //rigidBody of the pushed object
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
