using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Author: Eddie Huang 
 * this script is to control the display of the gui 
 * it has the score text , kill and the name of the level that the player is currently on 
 *
 */

public class levelManager : MonoBehaviour {

	 
	public Text scoreText;
	public Text killsText;
	public Text levelText;
	 
	private int score;
	private int kills;


	public GameObject player;
	public Button tryAgain;
	// Update is called once per frame


	void Start(){
		Scene scene = SceneManager.GetActiveScene ();
		levelText.text = "" + scene.name; // to get the name of the current active scene 

	}



	void Update () {
		if(playerController.score > score){
			score = playerController.score;

			scoreText.text = "Score:" + score;


		}


		if (playerController.kills > kills) {

			kills = playerController.kills;
			killsText.text = "Kills:"+kills;

		}

		if (player == null) {

			tryAgain.gameObject.SetActive (true);
			// if the player dies , it will display the try again button 

		}




	}
}
