using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this is to set the ball or projectile that controlled by magician zombie 
 * it will also be created at the front of the magician zombies but it keeps track of the players position and bounce back and forth 
 * 
 * 
 */

public class projectileBallMotion : MonoBehaviour {
 
	private GameObject officer;


	 
	private Vector3 currentPosition;


	private float timer;


	public float damageSpeed;
	void Awake(){
		 
		timer = 0f; 
		currentPosition = transform.position;

	}

	void Update(){


		officer = GameObject.FindGameObjectWithTag ("Player");


		timer += Time.deltaTime;

		if(officer.gameObject.transform.position.x < currentPosition.x)
		transform.position = new Vector3 (Mathf.PingPong(Time.time , currentPosition.x - officer.transform.position.x), transform.position.y,transform.position.z);
		else if(officer.gameObject.transform.position.x > currentPosition.x)
			transform.position = new Vector3 (Mathf.PingPong(-Time.time ,  officer.transform.position.x - currentPosition.x), transform.position.y,transform.position.z);
		if (timer > 5) {


			Destroy (gameObject);
		}
		// the projectile will be destroyed after 5 sec but will be regenerated again by the magician zombie if it is still alive 


	}


	 


	 
	}
 
