using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang
 * this script is to set the death zone for every object to clean up if the enemies , collectibles falls through , they will be destroyed  
*/


public class cleanerScript : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);


	}
}
