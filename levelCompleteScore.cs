using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Author: Eddie Huang
 * this to set the score and the number of enemies get killed  
 * it simply displays the score of the player achievements in each level 
 * the recorded will be made if the player gets higher score or more kills in each level 
 * 
 *
 */
public class levelCompleteScore : MonoBehaviour {

	void Upate(){
		string sceneName = SceneManager.GetActiveScene().name;


		if (sceneName == "Level1") {

			if (PlayerPrefs.GetInt ("Level1Kills") < playerController.kills) {
				PlayerPrefs.SetInt ("Level1Kills", playerController.kills);
			}
			if (PlayerPrefs.GetInt ("Level1Score") < playerController.score) {
				PlayerPrefs.SetInt ("Level1Score", playerController.score);
			}
		}
		if (sceneName == "Level2") {
			if (PlayerPrefs.GetInt ("Level2Kills") < playerController.kills) {
				PlayerPrefs.SetInt ("Level2Kills", playerController.kills);
			}
			if (PlayerPrefs.GetInt ("Level2Score") < playerController.score) {
				PlayerPrefs.SetInt ("Level2Score", playerController.score);

			}
		}

		if (sceneName == "Level3") {
			if (PlayerPrefs.GetInt ("Level3Kills") < playerController.kills) {
				PlayerPrefs.SetInt ("Level3Kills", playerController.kills);
			}
			if (PlayerPrefs.GetInt ("Level3Score") < playerController.score) {
				PlayerPrefs.SetInt ("Level3Score", playerController.score);
			}
		}

	}
}
