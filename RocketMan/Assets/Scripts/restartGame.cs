using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour {
    //public float restartTime;
    bool restartNow;
    float resetTime;

	// Use this for initialization
	void Start () {
        restartNow = false;
	}
	
	// Update is called once per frame
	void Update () {
        //check if its time to reload game
        //if (restartNow&& resetTime<=Time.time)
        //{
        //    //restart current level
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //}
		
	}
    public void restart_game()
    {
        //restartNow = true;
        //resetTime = Time.time + restartTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
