using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBlast : MonoBehaviour {
    public GameObject spore;
    public float shootTime;
    public Transform shootFrom;
    public int chanceShoot;

    //nextShootTime
    float nextShootTime;
    //reference to the cannon shoot animation
    Animator cannonAnim;

	// Use this for initialization
	void Start () {
        cannonAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&nextShootTime<Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if (Random.Range(0, 10) >= chanceShoot)
            {
                //start shooting
                Instantiate(spore, shootFrom.position, Quaternion.identity);
                cannonAnim.SetTrigger("cannonShoot");
            }

        }
    }
}
