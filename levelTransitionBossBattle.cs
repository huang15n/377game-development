using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Eddie Huang
 *this is for the level2 boss battle transition 
 *it is legacy code to make the transition after deafeat the boss 
 * 
 */

public class levelTransitionBossBattle : MonoBehaviour {

	public GameObject boss;
	 
	public int sceneIndex;


	void Update () {
		if (boss == null) {

			Invoke ("loadNextScene",4);
		}
	}

	public void loadNextScene(){
		SceneManager.LoadScene ("LoadingScene3");


	}


}
