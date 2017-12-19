using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * Author: Eddie Huang
 *this is for the player to shoot the bullet 
 *but i cannot figure if the player facing in right or left direction and it can only shoot in such direction 
 *which means the player can even shoot in the back if he is facing front 
 *but the basic mechanics is the same as the health controller 
 *
 *
 */

public class fireBullet : MonoBehaviour {

	public float shootingGap = 0.1f; 
	public GameObject projectile;
	public float nextBulletTime;
	private Vector3 rotationSetting;
	private AudioSource gunFireAudioSource;
	private playerController player;

	 
	public int maxAmmo;
	public int startAmmo;
	public int currentAmmo;
	public Image ammoImage;


	public GameObject bullet;
	 
	void Awake () {
		nextBulletTime = 0f;
		 
		gunFireAudioSource = GetComponentInParent<AudioSource> ();
		player = transform.root.GetComponent<playerController> ();
		currentAmmo = startAmmo;


	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetButton("Fire1") && nextBulletTime < Time.time) {
			if (currentAmmo >= 0) {
				singleShot ();
			}

		}
		// here to modify the single shot 
		// i hold the confusiong logic of how to make the constant open fire  


		 

	}

	public void addAmmos(int ammoValue){
		currentAmmo += ammoValue;
		if (currentAmmo >= maxAmmo) {

			currentAmmo = maxAmmo;

		}
		float amount = currentAmmo / 100.0f * 180.0f / 360; // set the ammo display the same as the health indicator 
		ammoImage.fillAmount = amount;

	}

	private void instantiateGunFire(){
		Instantiate (projectile, transform.position, Quaternion.Euler (rotationSetting));
		Instantiate (bullet, transform.position, bullet.transform.rotation);
		  // this is the bullet shell 

	}


	private void singleShot(){

		player.setFireAnimation ("openFireStanding");
		gunFireAudioSource.Play ();

		nextBulletTime = Time.time + shootingGap;

		if (player.getOrientation () == -1f) {

			rotationSetting = new Vector3 (0f, -90f, 0f);

		} else {

			rotationSetting = new Vector3 (0, 90, 0);

		}
		Invoke ("instantiateGunFire",0.4f);
		currentAmmo--;
		float amount = currentAmmo / 100.0f * 180.0f / 360;
		ammoImage.fillAmount = amount;

	}


	 





}
