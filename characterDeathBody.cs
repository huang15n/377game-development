using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 * 
 * this is to change the player's death body effect early script
 */

public class characterDeathBody : MonoBehaviour {
	private AudioSource characterDeathAudioSource;
	public AudioClip deathClip;
	// Use this for initialization


	void Start(){

		characterDeathAudioSource = GetComponent<AudioSource> ();

	}

	
	// Update is called once per frame
	void Update () {
		characterDeathAudioSource.PlayOneShot(deathClip);
		
	}
}
