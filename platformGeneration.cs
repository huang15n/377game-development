using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Eddie Huang
 * i draw this part on Ryan's advice , the section manager controlls the total amount of the sections 
 * this one is to set the next platform , however the gap of each two section are kept between the value so the player can fall down 
 * 
 */

public class platformGeneration : MonoBehaviour {
	 

	private GameObject sectionLevelManager;
	//public GameObject levelComplete;

	private SectionManager manager;

	private int counter = 0;


 



	void Awake(){
		sectionLevelManager = GameObject.FindWithTag ("sectionManager");
		manager = sectionLevelManager.GetComponent<SectionManager> ();

	}
	 



 
	void OnTriggerEnter(Collider other){
		 
		if (other.tag == "Player" && counter == 0) {
			 
		
			Vector3 generationPosition = new Vector3 (other.transform.position.x + Random.Range(21.5f, 22f), 0f, 0f);
				Vector3 rot = new Vector3 (0, 90, 0);
			manager.setPosition (generationPosition);
			manager.setRotation (rot);
		  
			  manager.makeNext ();
			counter ++;
	 
		

			}
		} /*else if (platformAmount == 3){


			Vector3 generationPosition = new Vector3 (other.transform.position.x + 22f, 0f, 0f);
			Vector3 rot = new Vector3 (0, 90, 0);
			Instantiate (levelComplete, generationPosition, Quaternion.Euler (rot));

			//levelSectionManager.makeNext();
				//makeNext will make the next level section and also delete the one I don't need anymore

		}*/


	}



 
