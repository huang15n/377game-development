using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this random spawn point generation script is made by the inspiration from Ryan 
 * i still insists to use this script instead of making ten prefabs 
 * because by the code i will be able to spawn each spawn point random and controlls the random number of the zombies 
 * 
 */


public class randomSpawnPointGeneration : MonoBehaviour {
	private int randomCounter;
	private float timeSet = 0;
	public GameObject[] spwanPoint;
	private int counter;

	void Awake(){

		counter = 0;

	}
 
	void Update () {

		randomCounter = Random.Range (1,3);

		if (timeSet <= randomCounter && counter <= 3) { 
				
		  
			Instantiate (spwanPoint [Random.Range (0, spwanPoint.Length)], transform.position, Quaternion.identity);
			counter++;

		} else {

			Destroy (gameObject);

		}
		timeSet += Time.deltaTime;



		
	}
}
