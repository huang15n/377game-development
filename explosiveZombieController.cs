using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang
   the explsoion zombies transit to the player's position when it first detects the player after 5 seconds 
   the player has to manage to run away from the place and try to defeat the zombie 
   the general motion moves as the regular zombie but it has no rigid body and it is not affected by gravity 


 */
public class explosiveZombieController : MonoBehaviour {



	public GameObject explosion;

 
	private Rigidbody zombieRB;

	public float walkSpeed;

	public GameObject zombie;
	public bool facingRight;
	Vector3 playerPosition;

	private bool detected;
	private bool firstDection;
	private Transform player;



	private Animator zombieAnimator;

	private enemyHealthController healthInvenurable;

	private AudioSource zombieSoundAudioSource;
	public AudioClip zombieSound;

	// Use this for initialization
	void Start () {
		healthInvenurable = GetComponentInParent<enemyHealthController> ();
		zombieRB = GetComponentInParent<Rigidbody> ();
		zombieAnimator = GetComponentInParent<Animator> ();
		zombieSoundAudioSource = GetComponentInParent<AudioSource> ();
		detected = false;
		if (Random.Range (1, 2) == 1) {
			facingRight = true;
			turnAround ();
		} else {

			facingRight = false;


		}

	}

	// Update is called once per frame
	void FixedUpdate () {



		if (detected) {


			if (player.position.x < transform.position.x && facingRight) {
				turnAround ();

			} else if (player.position.x > transform.position.x && !facingRight) {
				turnAround ();

			}



		} else {

			zombieAnimator.SetFloat ("walkSpeed",0);

		}


		if (detected && !facingRight) {

			 
		 
			zombieSoundAudioSource.PlayOneShot (zombieSound);

			zombieAnimator.SetFloat ("walkSpeed",1);

		} else if (detected && facingRight) {

		 
		 
			zombieSoundAudioSource.PlayOneShot (zombieSound);
			zombieAnimator.SetFloat ("walkSpeed",1);
		}




	}

	private void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {
			 
		 
				playerPosition = other.transform.position;
				Invoke ("teleportToPlayer", 3);
		 
			detected = true;
			player = other.transform;
			if (player.position.x < transform.position.x && facingRight ) {

				turnAround ();
			} else if (player.position.x > transform.position.x && !facingRight) {
				turnAround ();

			}

		}
		firstDection = false;

	}






	private void OnTriggerExit(Collider other){

		if (other.tag == "Player") {

			detected = false;
		}



	}






	private void turnAround(){
		facingRight = !facingRight;
		Vector3 changeOrientation = zombie.transform.localScale;
		changeOrientation.z *= -1;
		zombie.transform.localScale = changeOrientation;

	}



	private void teleportToPlayer(){

		zombieRB.transform.position = playerPosition;
		healthInvenurable.isInvincible = true; // set the health controller of the zombie as invincibel 
		Invoke ("explosionOccurance",1); // the explsoion will be conducted after 1 sec 



	}


	private void explosionOccurance(){
		Instantiate (explosion, transform.position, Quaternion.identity);
		// it instantiate the explosion effect that i created 
		 
		healthInvenurable.isInvincible = false;
		// after this explosion , the health controller back on the normal status and the player can destroy the zombie 
	}
}
