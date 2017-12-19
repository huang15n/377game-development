using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Eddie Huang
 * this is to set  pause menu 
 * when the pause menu is on , the other buttons are inactive 
 * 
 * 
 */

public class PauseScript : MonoBehaviour {

	public GameObject pauseButton,exitButton, pausePanel;
 
	void Update () {


		if (Input.GetKey (KeyCode.Escape)) {


			Pause ();




		}
		
	}

	public void Pause(){
		Time.timeScale = 0;
		pausePanel.SetActive (true);
		pauseButton.SetActive (false);
		exitButton.SetActive (false);
	 

	}

	public void Resume(){

		Time.timeScale = 1;
		pausePanel.SetActive (false);
		pauseButton.SetActive (true);
		exitButton.SetActive (true);

	}








}
