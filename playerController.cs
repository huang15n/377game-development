using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
 * Author: Eddie Huang
 *this script is the player controller script 
 *it defines the basic locomotion of the player and animation as well as audio 
 *the player can double jump , run , walk and fire 
 *the player can also collide with five types of powerups and make special edition of power , health , ammo , teleport, immune to attack , laser gun , last but not least , the rocket launcher to trigger the ending 
 *
 *
 *
 */

public class playerController : MonoBehaviour {
	public float runSpeed; // this is for  the running speed of the officer
	public float walkSpeed; // this is for the walk speed of the officer 
	private float walkRate;
	private float runRate;
	public float jumpHeight;// this is for the jump height of the officer 
	private Rigidbody officerRB; // this is to get the rigibody of the officer 
	private Animator officerAnimation;// this is to control the animation of the officer 
	private bool facingRight;

	private bool isGrounded;
	private Collider [] groundCollision;
	private float groundCheckRadius;
	public LayerMask groundLayer;
	public Transform groundCheckObject;
	private int jumpCount;// this is to make sure that the player can jump only twice 

	private CharacterAudioController characterAudio;
	private  Vector3 teleportPosition;

	public Text teleportLeftText;
	public GameObject explosions;








	public GameObject []particleEffect;

	public static int score = 0;

	public static int kills = 0;


	public int teleportCount = 5;




	private bool teleportTrigger;

	private playerHealthController health;


	public GameObject[] sheld;
	private float timeCountForInvincible = 0;
	private float timeCountForTeleport = 0;

	private float timeCountForlaserGun = 0;

	private float timeCountForHealth = 0;
	private float timeCountForAmmo = 0;

	private float timeCountTeleportLeft = 0;

	public GameObject[] weapons;


	private bool teleportDoubleJump;


	private bool final;



	void Awake () {

		officerRB = GetComponent<Rigidbody> ();
		officerAnimation = GetComponent<Animator> ();
		characterAudio = GetComponent<CharacterAudioController> ();
		health = GetComponent<playerHealthController> ();
		facingRight = true;
		isGrounded = false;
		groundCheckRadius = 0.2f;
		jumpCount = 0; // initalize the jump round to 0 

		teleportDoubleJump = true;


		teleportTrigger = false;



	}


	void FixedUpdate () {

		walkRate = Input.GetAxis ("Horizontal");
		// this is to get the speed of the officer to walk 
		runRate = Input.GetAxisRaw ("Fire3");
		// this is to set the rate to make the officer run 




		officerAnimation.SetFloat ("walkSpeed", Mathf.Abs(walkRate));
		// this is to set the parameter to let the player to correspond the walk aniamtion
		officerAnimation.SetFloat ("runSpeed", runRate);
		// this is to set the parameter to let the player to correspond the run aniamtion


		if (timeCountTeleportLeft <= 0) {
			teleportDoubleJump = true;
			teleportLeftText.gameObject.SetActive (false);

		}
		timeCountTeleportLeft -= Time.deltaTime;

		if (timeCountForInvincible <= 0) {

			sheld[0].SetActive (false);

		}
		timeCountForInvincible -= Time.deltaTime;


		if (timeCountForTeleport <= 0) {

			health.isInvincible = false;





		}


		if (timeCountForHealth <= 0) {

			sheld [1].SetActive (false);

		}

		timeCountForHealth -= Time.deltaTime;
		if (timeCountForAmmo <= 0) {

			sheld [2].SetActive (false);

		}
		timeCountForAmmo -= Time.deltaTime;


		timeCountForlaserGun -= Time.deltaTime;


		if (timeCountForlaserGun <= 0) {

			weapons[0].SetActive(true);
			weapons[1].SetActive (false);

		}


		timeCountForTeleport -= Time.deltaTime;


		if (final) {

			if (Input.GetKey(KeyCode.Mouse0)) {
				Instantiate (explosions, transform.position, Quaternion.identity);
				Invoke ("gameOver",1);

			}

		}



		if (Input.GetAxis ("Fire2") > 0) {
			if (facingRight) {
				officerAnimation.SetFloat ("walkSpeed", walkRate);
			} else {
				officerAnimation.SetFloat ("walkSpeed", -walkRate);

			}
		} else {

			if ( walkRate > 0 && !facingRight) {
				turnAround ();
			} else if(walkRate < 0 && facingRight ){
				turnAround ();
			}



		}





		// check if the officer is on the ground with overlap sphere 
		groundCollision = Physics.OverlapSphere (groundCheckObject.position, groundCheckRadius, groundLayer);
		if (groundCollision.Length > 0) {

			isGrounded = true;

			officerAnimation.SetBool ("isGrounded", isGrounded);
			jumpCount = 0;


		} else {

			isGrounded = false;
			officerAnimation.SetBool ("isGrounded", isGrounded);
		}



		if (Input.GetKeyDown(KeyCode.Space) && jumpCount <= 2 && teleportDoubleJump ) {

			jump ();
		}

		isGrounded = true;





		if (runRate > 0) {

			run ();

		}else {

			walk ();

			//this is to control the officer to walk horizontally 
		}


		if (teleportTrigger == true) {

			teleport ();

		}








	}


	private void run(){

		if (facingRight) {
			officerRB.velocity = new Vector3 (runRate * runSpeed, officerRB.velocity.y, 0f);
			//this is to control the officer to run horizontally 
		} else {

			officerRB.velocity = new Vector3 (-runRate * runSpeed, officerRB.velocity.y, 0f);
		}

	}


	private void walk(){

		officerRB.velocity = new Vector3 (walkRate * walkSpeed, officerRB.velocity.y, 0f);




	}


	private void jump(){
		if (jumpCount <= 2) {
			officerAnimation.SetTrigger ("jumpTrigger");
			isGrounded = false;
			officerAnimation.SetBool ("isGrounded", isGrounded);
			jumpCount++;

			officerRB.velocity = new Vector3 (jumpHeight, jumpHeight * 1.5f, 0f);
		}


	}



	private void turnAround(){

		facingRight = !facingRight;

		Vector3 currentScale = transform.localScale;
		currentScale.z *= -1;
		transform.localScale = currentScale;

	}

	public void setFireAnimation(string motion){

		officerAnimation.SetTrigger (motion);

	}

	public void setFireAnimation(string motion, bool fire){

		officerAnimation.SetBool (motion,fire);

	}



	public float getOrientation(){

		if (facingRight) {

			return 1;
		} else {

			return -1;
		}

	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Collectable") {
			Instantiate (particleEffect[0],transform.position, Quaternion.identity);
			characterAudio.collectableSound ();
			score++;
			Destroy (other.gameObject);

		}

		if (other.tag == "teleportPowerup" && teleportCount > 0) {

			teleportLeftText.gameObject.SetActive (true);
			teleportCount--;
			teleportLeftText.text = "Teleport Left:" + teleportCount;

			timeCountTeleportLeft = 8;
			jumpCount = 0;


			characterAudio.teleportSound ();
			Destroy (other.gameObject);
			teleportDoubleJump = false;
			teleportTrigger = true;



		}

		if (other.tag == "invinciblePowerup") {
			sheld[0].SetActive (true);
			characterAudio.teleportSound ();
			Destroy (other.gameObject);

			timeCountForInvincible = 8;

		}

		if (other.tag == "healthPickups") {
			sheld[2].SetActive (true);

			characterAudio.healthSound ();
			timeCountForHealth = 5;

		}

		if (other.tag == "ammoPickups") {
			sheld[2].SetActive (true);

			characterAudio.reloadSound ();
			timeCountForInvincible = 3;
			timeCountForAmmo = 3;
		}
		if (other.tag == "laserGun") {
			characterAudio.reloadSound ();
			Destroy (other.gameObject);
			weapons[0].SetActive (false);
			weapons[1].SetActive (true);
			timeCountForlaserGun = 30;


		}

		if (other.tag == "rocketLauncher") {

			Destroy (other.gameObject);
			weapons [0].SetActive (false);
			weapons [2].SetActive (true);
			final = true;


		}



	}

	private void teleport(){

		jumpCount = 0;




		if (Input.GetMouseButton (1)) {
			Vector3 mouseRay = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);

			RaycastHit hit;

			Ray ray= Camera.main.ScreenPointToRay (mouseRay);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				Debug.Log ("get it");
				teleportPosition = new Vector3 (hit.point.x, hit.point.y, 0.0f );

				transform.position = teleportPosition;
			}

			teleportTrigger = false;
		}

		timeCountForTeleport = 2;
		health.isInvincible = true;






	}


	private void gameOver(){

		SceneManager.LoadScene (7);


	}





}
