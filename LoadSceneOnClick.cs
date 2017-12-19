using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Author: Eddie Huang
 * this is to set the loading scene button click  
 * 
 */

public class LoadSceneOnClick : MonoBehaviour {
	public void LoadByIndex(int sceneIndex){
		
		SceneManager.LoadScene (sceneIndex);
		Time.timeScale = 1;
	}
  
	 
}
