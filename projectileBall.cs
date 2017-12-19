using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Eddie Huang
 * this is to set the ball or projectile that controlled by magician zombie 
 * it will also be created at the front of the magician zombies but it keeps track of the players position and bounce back and forth 
 * 
 * 
 */

public class projectileBall : MonoBehaviour {

	private playerHealthController healthController;
	public int damageValue;

	private GameObject officer;


	public float nextDamageRatio;
	 
	 

	public float damageSpeed;
	void Awake(){
		nextDamageRatio = 0.0f;
		damageSpeed = 0.1f;
		 
		officer = GameObject.FindGameObjectWithTag ("Player");
		healthController = officer.GetComponent<playerHealthController> ();



		 
	}

 

	private void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {


			Hurt ();

		}

	}


	private void OnTriggerStay(Collider other){

		if (other.tag == "Player") {



			Hurt ();
		}

	}





	private void Hurt(){


		if (nextDamageRatio <= Time.time) {

			healthController.addDamage (damageValue);
			nextDamageRatio +=  damageSpeed;



		}


	}

}
