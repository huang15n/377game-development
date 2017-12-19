using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang
 * this is the magician zombie to make the movement 
 * the magician zombie does not move , it controlls the ball only 
 * same as the regular zombie controller , but i do not add motion on it 
 */

public class projectileZombieController : MonoBehaviour {
	// public AudioClip[] zombieSoudClips;

	//private AudioSource zombieSoundAudioSource;
 public float walkSpeed;

	public GameObject zombie;
	public bool facingRight;


	private bool detected;
	private bool firstDection;
	private Transform player;

	private Animator zombieAnimator;


	 
	// Use this for initialization
	void Start () {
 
		zombieAnimator = GetComponentInParent<Animator> ();
	 
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

			zombieAnimator.SetTrigger ("attackTrigger");
			if (player.position.x < transform.position.x && facingRight) {
				
				turnAround ();


			} else if (player.position.x > transform.position.x && !facingRight) {
				turnAround ();
				 
			}



		} else {

			 

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
