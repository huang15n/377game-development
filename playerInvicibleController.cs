using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang
 * to set the player invicble by the shed 
 * this is legacy code 
 * 
 * 
 */
public class playerInvicibleController : MonoBehaviour {
	private GameObject enemy;
	private enemyHealthController enemyHealth;
	void OnTriggerEnter(Collider other){

		if (other.tag == "Enemy") {
			Destroy (other.gameObject);


		}

	}

}
