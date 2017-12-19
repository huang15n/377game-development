using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Author: Eddie Huang 
 * this is used for the score display 
 * it fetches the data in each new update of the achievement 
 * and then targeted to each corresponding seciton of the score scene
 * 
 */

public class ScoreSceneScript : MonoBehaviour {

	public Text level1Kills;
	public Text level1Score;
	public Text level2Kills;
	public Text level2Score;
	public Text level3Kills;
	public Text level3Score;


	private int level1kills;
	private int level1score;
	private int level2kills;
	private int level2score;
	private int level3kills;
	private int level3score;




	void Awake(){
		level1kills = PlayerPrefs.GetInt ("Level1Kills");
		level2kills = PlayerPrefs.GetInt ("Level2Kills");
		level3kills = PlayerPrefs.GetInt ("Level3Kills");
		level1score = PlayerPrefs.GetInt ("Level1Score");
		level2score = PlayerPrefs.GetInt ("Level2Score");
		level3score = PlayerPrefs.GetInt ("Level3Score");

		level1Kills.text = "Kills:"+level1kills;
		level1Score.text = "Score:"+level1score;
		level2Kills.text = "Kills:"+level2kills;
		level2Score.text = "Score:"+level2score;
		level3Kills.text = "Kills:"+level3kills;
		level3Score.text = "Score:"+level3score;






	}
	
 
 
}
