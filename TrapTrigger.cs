using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * this is to trigger the trap in the level two 
 * for instance like walls ,crates and etc to be active 
 */

public class TrapTrigger : MonoBehaviour {

	public GameObject[] traps;
	// Use this for initialization
 
	
	void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {

			for (int i = 0; i < traps.Length; i++) {

				traps [i].SetActive (true);

			}

		}

	}
}
