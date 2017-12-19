using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this is to set the health of the enemeis 
 * the enmies has the max health and the current health 
 * the same as the player health controller 
 * but once the enemies dies , the player will get one kill count 
 * since this rule only applies when the player really physically destroyed the enemy, if the enemy falls through the death zone does not count 
 * 
 * 
 */

public class enemyHealthController : MonoBehaviour {

	public int enemyMaxHealth;
	 
	public int currentHealth;
 

	private Rigidbody rbZombie;
	private Animator zombieAnimator;


	public GameObject[] powerups;
	public bool isInvincible = false;
	 


	public float thrust;

 
	 
	// Use this for initialization
	void Start () {
		currentHealth = enemyMaxHealth;
		zombieAnimator = GetComponentInParent<Animator> ();
		rbZombie = GetComponent<Rigidbody> ();// this is to set the push back force for the zombie body 
		// zombieMoaingAudioSource = GetComponent<AudioSource> ();
		 
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void enemeyGetDamage(int damageAmount){
		if (!isInvincible) {
			zombieAnimator.SetFloat ("walkSpeed", 0);
			rbZombie.AddForce (-transform.forward * thrust, ForceMode.Impulse); 

			currentHealth -= damageAmount;
			// zombieMoaingAudioSource.Play ();
			if (currentHealth <= 0) {
				enemyDeath ();


			}
		}

	}


	public void enemyDeath(){
		
		for (int i = 0; i < Random.Range (0, 4); i++) {
			GameObject thing = powerups [Random.Range (0, powerups.Length)];
			Instantiate (thing, transform.position, thing.transform.rotation);

		}
		playerController.kills++;

		Destroy (gameObject);
		 
		 
 



	}
}
