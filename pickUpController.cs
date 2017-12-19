using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this is the legacy code for pickups 
 * 
 */

public class pickUpController : MonoBehaviour {

	private int healthAmount;
	private int ammoAmount;
	private int coinsAmount;

	private AudioSource pickupAS;
	public AudioClip pickAudios;
	 
 
	void Awake(){


		healthAmount = 20;
		ammoAmount = 50;
		pickupAS = GetComponent<AudioSource> ();
	 

	}

	void OnTriggerEnter(Collider other){
		if (transform.gameObject.tag == "healthPickups" && other.tag == "Player") {
			other.GetComponent<playerHealthController> ().addHealth (healthAmount);
			pickupAS.PlayOneShot (pickAudios);

			Destroy (gameObject);

		}


		if (transform.gameObject.tag == "ammoPickups" && other.tag == "Player") {
			
			other.GetComponentInChildren<fireBullet> ().addAmmos (ammoAmount);
			pickupAS.PlayOneShot (pickAudios);
		 
			Destroy (gameObject);

		}


	}
	

 
}
