using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang
 * this script is to set the motion of the final boss 
 * it is also using the chasing script 
 * but special motions like punch and roaring is set particular to enlarge the priveildge of the boss 
 * the boss can turn around and run , so it is the avoidable chaser in this context 
 * 
 */
public class Boss2Script : MonoBehaviour {


	private Rigidbody bossRB;

	public float runSpeed;

	public GameObject boss;
	public bool facingRight;


	private bool detected;
	private bool firstDection;
	private GameObject player;

	private Animator bossAnimator;


	private AudioSource bossSoundAudioSource;
	public AudioClip bossSound;

 


	private float roarTime;

	// Use this for initialization
	void Start () {
		player  = GameObject.FindWithTag ("Player");
		roarTime = 0;
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


		if (Mathf.Abs (transform.position.x - player.transform.position.x) <= 2) {

			bossAnimator.SetTrigger ("attack");

		}


		if (detected) {


			if (player.transform.position.x < transform.position.x && facingRight) {
				turnAround ();

			} else if (player.transform.position.x > transform.position.x && !facingRight) {
				turnAround ();

			}



		} else {

			bossAnimator.SetFloat ("runSpeed",0);

		}


		if (detected && !facingRight) {
			if (roarTime <= 0) {
				bossRB.velocity = new Vector3 ((runSpeed * -1), bossRB.velocity.y, 0f);
				bossAnimator.SetFloat ("runSpeed", runSpeed);
				bossSoundAudioSource.PlayOneShot (bossSound);
			}


		} else if (detected && facingRight) {
			if (roarTime <= 0) {
				bossRB.velocity = new Vector3 ((runSpeed * 1), bossRB.velocity.y, 0f);

				bossAnimator.SetFloat ("runSpeed", runSpeed);
				bossSoundAudioSource.PlayOneShot (bossSound);
			}
		}

		roarTime -= Time.deltaTime;


	}

	private void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {
			roarTime = 1;
			firstDection = true;
			bossAnimator.SetBool ("roar",firstDection);
			detected = true;
			 
			if (player.transform.position.x < transform.position.x && facingRight ) {

				turnAround ();
			} else if (player.transform.position.x > transform.position.x && !facingRight) {
				turnAround ();

			}

			firstDection = false;

		}

	}






	private void OnTriggerExit(Collider other){

		if (other.tag == "Player") {

			detected = false;
		}



	}






	private void turnAround(){
		facingRight = !facingRight;
		Vector3 changeOrientation = boss.transform.localScale;
		changeOrientation.z *= -1;
		boss.transform.localScale = changeOrientation;

	}
}
