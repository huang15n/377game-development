using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this is to set the spider child to attack the player by collision and small explosions 
 */

public class spiderChildrenAttack : MonoBehaviour {



	// Use this for initialization
	public GameObject spiderChildPrefab;

	private GameObject spiderChild;
 

	public float nextGenerationTime = 0.0f;
	public float repeatRate = 3f;
	// Update is called once per frame

	private int counter = 0;


	void Update () {
		 
		if (counter <= 10) {
	
			if (Time.time > nextGenerationTime) {
				spiderChild = Instantiate (spiderChildPrefab, transform.position, Quaternion.identity) as GameObject;
				nextGenerationTime += repeatRate;
				 
				counter++;

			}
		}

		 
		
	}


 


	 
}
