using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour {
    //enemy speed
    public float enemySpeed;
    //reference to the animator of the boar
    Animator enemyAnimator;
    //reference to the boar gameObject
    public GameObject enemyGraphic;
    //variable to check whether the enemy can flip directions
    bool canFlip = true;
    //variable to check where our enemy is facing
    bool facingRight=false;
    //rate at which our enemy can flip directions
    float flipTime = 5.0f;
    float nextFlipChance = 0f;
    //time before we start attacking the character
    public float chargeTime;
    float startChargeTime;
    //check if we are charging
    bool isCharging=false;
    //rigidbody
    Rigidbody2D enemyRB;
	// Use this for initialization
	void Start () {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //determine if the enemy can flip back and forth
        if (Time.time > nextFlipChance)
        {
            if (Random.Range(0, 10) >= 5)
            {
                //flip the boar round
                flipFacing();
            }
            nextFlipChance = Time.time + flipTime;
        }
	}
    void flipFacing()
    {
        //if the enemy is attacking do nothing
        if (!canFlip) return;
        //get the scale value of the creature
        float facingX = enemyGraphic.transform.localScale.x;
        //flip the creature
        facingX *= -1f;
        enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
        facingRight = !facingRight;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //make sure its the character that is within range
        if (collision.tag == "Player")
        {
            //make sure enemy is facing the character
            if (facingRight && collision.transform.position.x < transform.position.x)
            {
                flipFacing();
            }else if(!facingRight && collision.transform.position.x > transform.position.x)
            {
                flipFacing();
            }
            //keep on attacking
            canFlip = false;
            isCharging = true;
            startChargeTime = Time.time + chargeTime;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (startChargeTime < Time.time)
            {
                
                if (facingRight)
                {
                    enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                }
                else
                {
                    enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                }
                //change animation from idle to running
                enemyAnimator.SetBool("isCharging", true);
            }
        }
    }
    //player gets out of our line if sight
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
            isCharging = false;
            enemyRB.velocity = new Vector2(0, 0);
            enemyAnimator.SetBool("isCharging", false);
        }
    }
}
