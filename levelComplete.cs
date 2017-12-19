using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Eddie Huang
 * 
 * this is to set the loading scene 
 * 
 */

public class levelComplete : MonoBehaviour {
	public int sceneIndex;
 

	private void Awake(){

	 


	}



	private void OnTriggerEnter(Collider other){




		loadScene (sceneIndex);


	}


	public void loadScene(int sceneIndex){

		SceneManager.LoadScene (sceneIndex);


	}




}
