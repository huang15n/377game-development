using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang
 * this script is for the explosition damage to the player 
 * same as the enemy damage but it has no animation so i have to separately write a script for it 
 */
public class explosionEffect : MonoBehaviour {
	private playerHealthController healthController;
	public int damageValue;
	 
	private GameObject officer;


	public float nextDamageRatio;
	public AudioClip explosionSound;
	private AudioSource explosionAS;



	private float timer;


	public float damageSpeed;
	void Awake(){
		nextDamageRatio = 0.0f;
		damageSpeed = 0.1f;
		timer = 0f; 
		explosionAS = GetComponent<AudioSource> ();

	}
   
	void Update(){
		explosionAS.PlayOneShot (explosionSound);
			transform.localScale = new Vector3 (Mathf.PingPong (Time.time * 10, 6), 1f, 1f);
			officer = GameObject.FindGameObjectWithTag ("Player");
			healthController = officer.GetComponent<playerHealthController> ();
		timer += Time.deltaTime;
		if (timer > 1) {


			Destroy (gameObject);
		}

		 

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
