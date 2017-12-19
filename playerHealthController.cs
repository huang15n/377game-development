using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
 * Author: Eddie Huang
 * this is to control the officer health and make the circle health point display on the screen 
 * the splash blood screen technique uese the alpha channel and the color change technique 
 * each time when player gets hurt , the health point is reduced while the alpha value of the blood picture is shown 
 * once the player is dead , in other words, the player gets destroyed ,the whole death image will be set active 
 * 
 */



public class playerHealthController : MonoBehaviour {
	public float officerFullHealth; // the officers full health 
	public float officerCurrentHealth; // the officers current health 
	public Image healthIndicator; // this is the gui indicator 
	public Image bloodScreen; // i set the splash blood image in the camera 
	public Image deathScreen; // this is the death screen 
	private Color splashColor;
	private float splashSpeed;
	private bool playerGetDamaged;


	public AudioClip hurtClip;
	public AudioClip heartBeatingClip;
	private AudioSource characterAudioSource;


	public GameObject playerDeathBody;



	public bool isInvincible = false;
 

	// Use this for initialization
	void Start () {
		officerCurrentHealth = officerFullHealth;
		splashColor = new Color (255f,255f,255f,1f); // this is the original color value of the blood image 
		playerGetDamaged = false;
		splashSpeed = 5f;
		characterAudioSource = GetComponent<AudioSource> ();
		 
	}
	
	// Update is called once per frame
	void Update () {
		if (playerGetDamaged) {

			bloodScreen.color = splashColor;

		} else {

			bloodScreen.color = Color.Lerp(bloodScreen.color,Color.clear,splashSpeed * Time.deltaTime);
			// use the color lerp in the screen , to smoothly transit the blood image 

		}
		playerGetDamaged = false;


	 


	 

		
	}

	// this is to add the health point of the player if player collects the health powerups 
	public void addHealth(float healthValue){
		characterAudioSource.PlayOneShot (heartBeatingClip);
		officerCurrentHealth += healthValue;
		if (officerCurrentHealth > officerFullHealth) {
			officerCurrentHealth = 100; // if the player has the full health , it is reset to 100 

		}
		float amount = officerCurrentHealth / 100.0f * 180.0f / 360;
		healthIndicator.fillAmount = amount;
		// the health indicator is drawn on the online guidance ,with 100.0f means the total value of the health * 180 means the convex 

	}


	// this is to add damage to the player 

	public void addDamage(int damageValue){
		if (!isInvincible) {
			characterAudioSource.PlayOneShot (hurtClip);
			officerCurrentHealth -= damageValue;
			playerGetDamaged = true;
			float amount = officerCurrentHealth / 100.0f * 180.0f / 360;
			healthIndicator.fillAmount = amount;
			if (officerCurrentHealth <= 0) { // if the health point is less equal to 0, player dies 
			
				playerDeath ();

			}

		}

	}
	// when player dies , it will reset the scores and kills as well as save all the achievement aquire so far 

	public void playerDeath(){
		
		string sceneName = SceneManager.GetActiveScene().name;

		 
		if (sceneName == "Level1") {
			
			if (PlayerPrefs.GetInt ("Level1Kills") < playerController.kills) {
				PlayerPrefs.SetInt ("Level1Kills", playerController.kills);
			}
			if (PlayerPrefs.GetInt ("Level1Score") < playerController.score) {
				PlayerPrefs.SetInt ("Level1Score", playerController.score);
			}
		}
		if (sceneName == "Level2") {
			if (PlayerPrefs.GetInt ("Level2Kills") < playerController.kills) {
				PlayerPrefs.SetInt ("Level2Kills", playerController.kills);
			}
			if (PlayerPrefs.GetInt ("Level2Score") < playerController.score) {
				PlayerPrefs.SetInt ("Level2Score", playerController.score);

			}
		}

		if (sceneName == "Level3") {
			if (PlayerPrefs.GetInt ("Level3Kills") < playerController.kills) {
				PlayerPrefs.SetInt ("Level3Kills", playerController.kills);
			}
			if (PlayerPrefs.GetInt ("Level3Score") < playerController.score) {
				PlayerPrefs.SetInt ("Level3Score", playerController.score);
			}
		}




		playerController.score = 0;
		playerController.kills = 0;





		bloodScreen.color = splashColor;
		Instantiate (playerDeathBody, transform.position,Quaternion.identity);
		Destroy (gameObject);
		deathScreen.gameObject.SetActive (true);



	}



}
