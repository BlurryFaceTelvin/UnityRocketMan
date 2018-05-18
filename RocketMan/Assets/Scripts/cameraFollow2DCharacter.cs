using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DCharacter : MonoBehaviour {
    //variable for the object that the camera would follow
    public Transform target;
    //variable for how quickly the camera would follow a target
    public float smoothing;
    //difference of the camera position and game object position
    Vector3 offset;
    //variable for the lowest point a camera would go in the y position
    float lowY;
	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
        lowY = transform.position.y;
		
	}
	
	// FixedUpdate is called after a specific amount of  time
	void FixedUpdate () {
        //get the camera position
        Vector3 targetCameraPosition = target.position + offset;
        //slowly transform into the new position
        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, smoothing*Time.deltaTime);
        //prevent camera from following a falling object
        if (transform.position.y < lowY)
        {
            //reposition
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
	}
}
