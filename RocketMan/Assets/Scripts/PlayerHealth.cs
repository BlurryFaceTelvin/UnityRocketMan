using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public GameObject deathFx;
    //variable for the max and current health of the player
    public float maxHealth;
    float currentHealth;
    //reference to the player controller
    PlayerController myPC;
    //Hud variables
    public Slider healthSlider;
    public Image damageScreen;
    public Text gameOverScreenText, gameWinScreenText;
    public Button restartBtn,replayBtn;
    //screenflash variables
    Color damagedColor;
    float smoothColor;
    //variable to check whether the character is damaged
    bool damaged;
    //audio
    public AudioClip playerHurtSound,playerDeathSound;
    private AudioSource playerAS;
    //animations
    Animator gameOverTextAnim, gameWinTextAnim;
    Animator restartBtnAnim,replayBtnAnim;
    //reference to the restartGame class
    public restartGame theGameManager;

	// Use this for initialization
	void Start () {
        myPC = GetComponent<PlayerController>();
        currentHealth = maxHealth;
        //Hud initialization
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        damaged = false;
        damagedColor = new Color(255f, 255f, 255f, 0.5f);
        smoothColor = 2f;
        playerAS = GetComponent<AudioSource>();
        //anim initialization
        gameOverTextAnim = gameOverScreenText.GetComponent<Animator>();
        gameWinTextAnim = gameWinScreenText.GetComponent<Animator>();
        restartBtnAnim = restartBtn.GetComponent<Animator>();
        replayBtnAnim = replayBtn.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        //if you are damaged flash the damage screen
        if (damaged)
        {
            //flashing screen
            damageScreen.color = damagedColor;
        }
        else
        {
            //remove the damagescreen
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor*Time.deltaTime);
        }
        //set damaged to false
        damaged = false;
	}
    //method to be called when player takes damage
    public void playerHit(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        //play a sound
        playerAS.PlayOneShot(playerHurtSound);

        healthSlider.value = currentHealth;
        damaged = true;
        if (currentHealth <= 0)
        {
            //player is dead
            makeDead();
        }
    }
    //method for what happens when player collects health
    public void healthGain(float healthAmount)
    {   
        currentHealth += healthAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthSlider.value = currentHealth;
    }
    public void makeDead()
    {
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        Instantiate(deathFx, transform.position, transform.rotation);
        currentHealth = 0;
        healthSlider.value = currentHealth;
        //destroy our game object
        Destroy(gameObject);
        //show the damaged color
        damageScreen.color = damagedColor;
        //start the animations for the game over text and restart button
        gameOverTextAnim.SetTrigger("gameOver");
        Debug.Log(restartBtnAnim);
        restartBtnAnim.SetTrigger("gameOver");
        
    }
    //when we win the game
    public void winGame()
    {
        //destroy the character
        Destroy(gameObject);
        //start animations
        gameWinTextAnim.SetTrigger("gameOver");
        replayBtnAnim.SetTrigger("gameOver");
    }
}
