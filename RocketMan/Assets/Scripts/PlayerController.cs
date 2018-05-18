using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {
    //movement variables
    public float maxSpeed;
    //reference to the rigidbody for the characters rigidbody
    Rigidbody2D myRb;
    //reference to the animator
    Animator myAnim;
    //variable to check where user is facing right or left side
    bool facingRight;
    //variable vertical movements
    bool isGrounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    //location for the circle
    public Transform groundCheck;
    //force of jumping
    public float jumpForce;
    //shooting variables
    public Transform gunTip;
    public GameObject missle;
    //how fast the character shoots
    float FireRate = 0.5f;
    float nextFire = 0f;
	// Use this for initialization
	void Start () {
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
        
	}
    //is called per frame
    void Update()
    {
        //player movement
        float moveUp = Input.GetAxis("Jump");
        //if player is on the ground and user has press space bar
        if (isGrounded && moveUp > 0)
        {
            isGrounded = false;
            //change the value of is grounded to make animation transition
            //from any state to jumpfallblend
            myAnim.SetBool("isOnGround", isGrounded);
            myRb.AddForce(new Vector2(0, jumpForce));
        }
        //player shooting
        float shoot = Input.GetAxis("Fire1");
        //if player has pressed the shoot key which is the left mouse key
        if (shoot > 0)
        {
            fireMissle();
        }

    }

    //is called after a specific amount of time
    void FixedUpdate()
    {
        //check if the player is on the ground if no we be falling
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetFloat("verticalSpeed",myRb.velocity.y);
        myAnim.SetBool("isOnGround", isGrounded);
        float move = Input.GetAxis("Horizontal");
        //change the value of the speed for animation transition
        myAnim.SetFloat("speed", Math.Abs(move));
        //a values between -1-0
        //d values between 0-1
        //manipulate the x value for the player
        myRb.velocity = new Vector2(move*maxSpeed, myRb.velocity.y);
        //check the button that user is pressing and move accordingly
        //user press d or right arrow
        if (move > 0&&!facingRight)
        {
            //character face right 
            flip();

        }//user presses the left arrow or the a key
        else if (move < 0 && facingRight)
        {
            //character face left
            flip();
        }

    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        //make the character face the opposite direction
        scale.x *= -1;
        transform.localScale = scale;
    }
    void fireMissle()
    {
        //check if we can fire since we have a constraint on the rate of fire which is half a second
        if (Time.time > nextFire)
        {
            nextFire = Time.time + FireRate;
            //check where the chacter is facing
            if (facingRight)
            {
                Instantiate(missle, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if(!facingRight)
            {
                Instantiate(missle, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
}
