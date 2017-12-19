using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * to set the prebs or platforms to be destroyed after certain amount of time 
 */


public class DestroyThat : MonoBehaviour {
	public float lifeTime;
	// Use this for initialization
	void Awake () {
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	 
}
