using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this scritp is meant to control the first boss riho 
 * the basic motion moves as the classic 2d scorlling 
 * if the boss detects it moves to the direction that the player is staying 
 * for this script , it is intended to make effect the player has to run and reach the end 
 * but if the player decided to defeat the boss, the player can get the collectibles 
 */

public class Boss1Script : MonoBehaviour {

	 
	private Rigidbody bossRB;

	public float runSpeed;

	public GameObject boss;
	public bool facingRight;


	private bool detected;
	private bool firstDection;
	private Transform player;

	private Animator bossAnimator;


	private AudioSource bossSoundAudioSource;
	public AudioClip bossSound;

	// Use this for initialization
	void Start () {
		bossRB = GetComponentInParent<Rigidbody> ();
		bossAnimator = GetComponentInParent<Animator> ();
		bossSoundAudioSource = GetComponentInParent<AudioSource> ();
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

			bossAnimator.SetFloat ("runSpeed",0); // set the animation of the boss 

		}


		if (detected && !facingRight) {

			bossRB.velocity = new Vector3 ((runSpeed * -1), bossRB.velocity.y, 0f);
			bossAnimator.SetFloat ("runSpeed",runSpeed);
			bossSoundAudioSource.PlayOneShot (bossSound);



		} else if (detected && facingRight) {

			bossRB.velocity = new Vector3 ((runSpeed * 1), bossRB.velocity.y, 0f);

			bossAnimator.SetFloat ("runSpeed",runSpeed);
			bossSoundAudioSource.PlayOneShot (bossSound);

		}




	}


	// this is to change the direction of the player 

	private void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {

			detected = true; // set the detected as true to further the motion 
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
	// if the player jumps or moves out of the detection zone, the boss will stop 





	private void turnAround(){
		facingRight = !facingRight;
		Vector3 changeOrientation = boss.transform.localScale;
		changeOrientation.z *= -1;
		boss.transform.localScale = changeOrientation;

	}
}
