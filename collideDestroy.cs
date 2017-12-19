using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * if the player jumps on the top of the enemy, the enemy will be destroyed 
 */


public class collideDestroy : MonoBehaviour {

	private void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			 
			Destroy (transform.parent.gameObject);

		}


	}
}
