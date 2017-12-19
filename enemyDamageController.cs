using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this is to set the enemy damages applied t the player
 * the script is designed to any enemies with the fighting ability 
 */

public class enemyDamageController : MonoBehaviour {
	public int damageValue; // the damage valu3 wants to add on the player 
	public float damageSpeed; // the damage speed 
	public float nextDamageRatio; // the time interval 
	public bool playerInRange;  // if the player is in range 

	private GameObject officer;
	private playerHealthController healthController;
	 


	private Animator zombieAnimator;


	// Use this for initialization
	void Start () {
		nextDamageRatio = 0f;
		zombieAnimator = GetComponentInParent<Animator> ();
		 
		officer = GameObject.FindGameObjectWithTag ("Player");
		healthController = officer.GetComponent<playerHealthController>();
	}
	
	 

	// to set the damage either player stills in the detection zone or off the stays in the detection zone 
 

	private void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {

			playerInRange = true;
			 
			zombieAnimator.SetFloat ("walkSpeed",0);
			zombieAnimator.SetTrigger ("attack");
			Hurt ();

		}

	}


	private void OnTriggerStay(Collider other){

		if (other.tag == "Player") {

			playerInRange = true;
			 
			zombieAnimator.SetFloat ("walkSpeed",0);
			zombieAnimator.SetTrigger ("attack");
			Hurt ();
		}

	}


	private void OnTriggerExit(Collider other){

		if (other.tag == "Player") {

			playerInRange = false;
			 

		}

	}


	private void Hurt(){

		if (nextDamageRatio <= Time.time) {

			healthController.addDamage (damageValue);
			nextDamageRatio += Time.time + damageSpeed;
			 


		}

	}


	 


}
