using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang 
 *this is the regular spwan point 
 *it instantiate the prefab with its original rotation set by the developer 
 *
 */
public class spawnPointScript : MonoBehaviour {


	public GameObject [] spawnThings;
 
	Vector3 newPosition;
	// Use this for initialization
	private GameObject platform;

	private GameObject thing;

 
 
	void Start(){
 
	 
	}
	// Update is called once per frame
	void Awake () {

		//transform.position = newPosition;
		//if (nextInstantiation < Time.time && enemyCounter <= 3) {

		//	nextInstantiation = Time.time + timeInterval;

			dynamicSpawn ();


		//}
    
 

	}

	void dynamicSpawn(){
	  //   newPosition.x = platformPosition.x + Random.Range(-5,5);
	    //newPosition.y =  3f;
		 //newPosition.z = 0f;
	 
			thing = spawnThings [Random.Range (0, spawnThings.Length)];

	
			Vector3 rot = new Vector3 (0, 90, 0);
			Instantiate (thing, transform.position, thing.transform.rotation);
	 
		Destroy (gameObject,3);
	 
	}



}
