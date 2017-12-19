using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Eddie Huang
 * this is to set the motion of the enemies 
 * all need to thank Ryan teaching me about 2d scrolling enemy motion instead of using the navmesh agent 
 * because the nav mesh agent does not work in the platform i configure and this is simpler to do 
 * the enemy detects the player in the box collider and moves to the player's transfom position 
 * since the enemy has the rigidbody i set the velocity.x to move sideways 
 * 
 */

public class enemyMotionController : MonoBehaviour {



	 
	private Rigidbody zombieRB;

	public float walkSpeed;

	public GameObject zombie;
	public bool facingRight;


	private bool detected;
	private bool firstDection;
	private Transform player;

	private Animator zombieAnimator;


	private AudioSource zombieSoundAudioSource;
	public AudioClip zombieSound;

	// Use this for initialization
	void Start () {
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

			zombieRB.velocity = new Vector3 ((walkSpeed * -1), zombieRB.velocity.y, 0f);
			zombieAnimator.SetFloat ("walkSpeed",walkSpeed);
			zombieSoundAudioSource.PlayOneShot (zombieSound);



		} else if (detected && facingRight) {

			zombieRB.velocity = new Vector3 ((walkSpeed * 1), zombieRB.velocity.y, 0f);

			zombieAnimator.SetFloat ("walkSpeed",walkSpeed);
			zombieSoundAudioSource.PlayOneShot (zombieSound);

		}




	}

	private void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {

			detected = true;
			player = other.transform;
			if (player.position.x < transform.position.x && facingRight ) {

				turnAround ();
			} else if (player.position.x > transform.position.x && !facingRight) {
				turnAround ();

			}

		}

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
}
