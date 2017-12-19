using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this is the legacy code for the floor to spawn thing 
 * it has been replaced by the random spawn script 
 * 
 */

public class platformSpawn : MonoBehaviour {

	public GameObject[] items;

	private GameObject thing; 


	private float timeInterval;

	private float nextInstantiation;

	private int enemyCounter;


	void Start(){
		 
		nextInstantiation = 0.1f;
		timeInterval = 0.5f;
		enemyCounter = 0;

	}
	
    
	void Update () {
		 
		if (nextInstantiation < Time.time && enemyCounter <= 2) {

			 
			thing = items [Random.Range (0, items.Length)];
			nextInstantiation = Time.time + timeInterval;

			 
			Instantiate (thing, transform.position, thing.transform.rotation);


			enemyCounter++;
	 
	      


		}

		Destroy (gameObject, 5);

		
	}
}
