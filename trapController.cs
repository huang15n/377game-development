using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapController : MonoBehaviour {

	public int damageValue;
	public float damageSpeed;
	public float nextDamageRatio;
	public bool playerInRange;

	private GameObject officer;
	private playerHealthController healthController;



 


	// Use this for initialization
	void Start () {
		nextDamageRatio = 0f;
	 

		officer = GameObject.FindGameObjectWithTag ("Player");
		healthController = officer.GetComponent<playerHealthController>();
	}






	private void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {

			playerInRange = true;

		 
			Hurt ();

		}

	}


	private void OnTriggerStay(Collider other){

		if (other.tag == "Player") {

			playerInRange = true;

		 
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
