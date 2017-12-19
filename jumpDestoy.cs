using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 *  when the player jumps on the top of the enemy , the enemy gets destroyed 
 * 
 */

public class jumpDestoy : MonoBehaviour {

	private enemyHealthController enemyHealth;

	void Start(){
		enemyHealth = GetComponentInParent<enemyHealthController> ();


	}

	private void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			enemyHealth.enemyDeath ();

		}

	}
 
}
