using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang
 * legacy code for the zombei animator 
 * 
 */

public class zombieAnimatorController : MonoBehaviour {
	private Animator zombieAttackAnimator;
	// Use this for initialization
 

	void Awake(){

		zombieAttackAnimator = GetComponentInParent<Animator> (); 
	 

	}

 


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Debug.Log ("zombie attack");
			zombieAttackAnimator.SetTrigger ("zombieAttack");
		 
		}

	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			Debug.Log ("zombie attack stays");
			zombieAttackAnimator.SetTrigger ("zombieAttack");
			 
		}

	}

	void OnTriggerExit(Collider other){

		if (other.tag == "Player") {
 
		}

	}
}
