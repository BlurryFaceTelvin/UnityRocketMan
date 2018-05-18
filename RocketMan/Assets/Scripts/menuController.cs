using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour {
    //reference to restart game
    public restartGame myRestart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
        {
            //quit the game
            Application.Quit();
        }
		
	}
    public void quitGame()
    {
        //quits game
        Application.Quit();
    }
    public void replayGame()
    {
        //replay the game
        myRestart.restart_game();
    }
    public void restartGame()
    {
        //restart the game
        myRestart.restart_game();
    }
}
