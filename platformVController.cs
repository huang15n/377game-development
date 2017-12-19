using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Eddie Huang
    this is to controll the floor move back and forth 
      it has already appears in assignent1 
 * 
 */

public class platformVController : MonoBehaviour {
	public float speed = 0.8f;
 // Update is called once per frame

    
	private Rigidbody body;


	void Start(){

		body = GetComponent<Rigidbody> ();

	}

	void Update () {
		if(transform.tag == "horizontalPlatform")
		transform.position = new Vector3 (Mathf.PingPong(Time.time * speed, 4), transform.position.y,transform.position.z);
		if(transform.tag == "verticalPlatform")
			transform.position = new Vector3 ( transform.position.x,Mathf.PingPong(Time.time * speed, 4),transform.position.z);  
	}

 



}
