using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this is for the magacian zombie to control the balls every 5secs  
 * 
 */

public class projectileInstanitiation : MonoBehaviour {
 

 

	public GameObject thing; 


	private float timeInterval;

	private float nextInstantiation;

 

	void Start(){

		nextInstantiation = 0.1f;
		timeInterval = 5f;
		 

	}


	void Update () {

		if (nextInstantiation < Time.time) {


			 
			nextInstantiation = Time.time + timeInterval;

			 
			Instantiate (thing, transform.position, thing.transform.rotation);


		 




		}

		 


	}
}
