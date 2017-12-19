using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Eddie Huang
 *  this platform is for the final battle 
 * the spawn point will be set to falling some powersup 
 * since the position of the powerup is uncontrollable , so i give up creating the powerup and just let the player to run 
 * legacy code 
 * 
 * 
 */

public class finalBattleScene : MonoBehaviour {
	 
	private float timeSet = 0;
	public GameObject[] spwanPoint;
	private int counter;
	Vector3 newPosition;



	void Awake(){

		counter = 0;
		newPosition.x = transform.position.x + Random.Range (-10, 10);
		newPosition.y = transform.position.y + Random.Range (0, 1);

		newPosition.z= 0f;


		transform.position = newPosition;

	}

	void Update () {

		newPosition.x = transform.position.x + Random.Range (-10, 10);
		newPosition.y = transform.position.y + Random.Range (1, 2);

		newPosition.z= 0f;


		transform.position = newPosition;

		if (  counter <= 40) { 

			Vector3 newPosition = transform.position;
			newPosition.y += 2;

			Instantiate (spwanPoint[0], newPosition, Quaternion.identity);
			counter++;

		} else {

			Destroy (gameObject);

		}
		timeSet += Time.deltaTime;




	}
}
