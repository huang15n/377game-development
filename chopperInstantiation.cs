using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang 
 *this script is to make the rocket laucher to be instantiate by the chopper when player enters the last zone 
 *the chopper drops the roket launcher so the player pick up and trigger the end of the game 
 *
 *
 */
public class chopperInstantiation : MonoBehaviour {
	public GameObject rocketLauncher;

 


	void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {
			 
			Vector3 newPos = transform.position;
			newPos.y -= 2;
			Instantiate (rocketLauncher, newPos, Quaternion.identity);

		}

	}
 
      
}
