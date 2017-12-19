using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this is to make the random range of the spawn point 
 * this script is set to be relative to the platform's position 
 * within the prefab pack inside another prefab pack , the enemy , collectible,floors and powerups combination can be numerous  
 */

public class spawnEnemyPosition : MonoBehaviour {
	 
	Vector3 newPosition;
	// Use this for initialization
	void Awake(){


	
		newPosition.x = transform.position.x + Random.Range (-8, 5);
		newPosition.y = transform.position.y + Random.Range (0, 1);
		 
		newPosition.z= 0f;


		transform.position = newPosition;



	}
	void Update(){

		newPosition.x = transform.position.x + Random.Range (-5, 5);
		newPosition.y = transform.position.y + Random.Range (0, 1);

		newPosition.z= 0f;


		transform.position = newPosition;


	}
}
