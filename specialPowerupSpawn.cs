using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Eddie Huang
 * this is special powerup spwan point script 
 * it is meant for the speical powerup like laser guns and teleport 
 */

public class specialPowerupSpawn : MonoBehaviour {

	private GameObject player;
	public GameObject [] specials;
	private int countForTeleport;
	private int counter;

	void Awake(){

		counter = 0;

	}


	// Update is called once per frame
	void Update () {

		player = GameObject.FindGameObjectWithTag ("Player");

		countForTeleport = player.GetComponent<playerController> ().teleportCount;


		if (counter <= 1) {
			if (countForTeleport >= 0) {
				Instantiate (specials [Random.Range (0, specials.Length)], transform.position, Quaternion.identity);

			} else {
				Instantiate (specials [Random.Range (0, 1)], transform.position, Quaternion.identity);
			}



		}
		counter++;



		
	}
}
