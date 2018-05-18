using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sporeController : MonoBehaviour {
    public float sporeSpeedHigh;
    public float sporeSpeedLow;
    public float sporeShootAngle;
    public float sporeTorqueAngle;
    //Rigidbody reference
    Rigidbody2D sporeRB; 


	// Use this for initialization
	void Start () {
        sporeRB = GetComponent<Rigidbody2D>();
        sporeRB.AddForce(new Vector2(Random.Range(-sporeShootAngle,sporeShootAngle),Random.Range(sporeSpeedLow,sporeSpeedHigh)),ForceMode2D.Impulse);
        //spin
        sporeRB.AddTorque(Random.Range(-sporeTorqueAngle,sporeTorqueAngle));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
