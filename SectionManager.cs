using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Eddie Huang
 * with Ryan's help , i am able to figure out the dynamic section generation 
 * the section manager manipualtes how many secitons in total that the game is about to create 
 * the start section is indepent to all the others 
 * once the player triggers the section generator in the platform , the next section is create 
 * to destroy the previous section , Ryan guided me to use the algorithm of replacement in three object 
 * current= previous 
 * current=next 
 * once the next is triggered and the previous gets destroy 
 * once it reach 10th platforms , the level complete platform appears . 
 * appreciations to Ryan again .
 *
 */

public class SectionManager : MonoBehaviour {




	public GameObject[] platforms;
	public GameObject levelComplete;
	private int platformAmount = 0;
	private Vector3 newposition;
	private Vector3 newRotation;


	private GameObject previousPlatform;
	private GameObject currentPlatform; 
	private GameObject nextPlatform;
	private int counter = 0;

	public GameObject startPlatform;

	private void Start(){

		platformAmount = 0;

	}


	public void setPosition(Vector3 pos){
		newposition = pos;  


	}

	public void setRotation(Vector3 rot){

		newRotation = rot; // i have to change the special rotation of the platform because the platform is not facing 90 degrees in the model 

	}

	// this is to make the next platform 
	public void makeNext(){

		if (platformAmount >= 1 && startPlatform != null) { 

			Destroy (startPlatform); // only if the platform amount is greater than two means the second platform is generated then destroy the first platform 
		}
		 
		if (platformAmount <= 9) {
			currentPlatform = nextPlatform;
			nextPlatform = Instantiate (platforms [Random.Range (0, platforms.Length)], newposition, Quaternion.Euler (newRotation));
	 

			Destroy (previousPlatform);
			previousPlatform = currentPlatform;

 
			platformAmount++;


		

		} else {
			newposition.x += 1; // this is to change the position of the level complete 
			Instantiate (levelComplete, newposition, Quaternion.Euler (newRotation));

		}

	}


 
 
}
