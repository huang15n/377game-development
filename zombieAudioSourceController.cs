using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang
 * this is for the zombie audios 
 * it is also legacy code 
 * 
 */

public class zombieAudioSourceController : MonoBehaviour {
	public AudioClip[] zombieAudioClips;
	private AudioSource zombieAudioSource;
	// Use this for initialization
	void Awake () {
		zombieAudioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	private void zombieWalk(){
		zombieAudioSource.PlayOneShot (zombieAudioClips[0]);
		zombieAudioSource.PlayOneShot (zombieAudioClips[1]);

	}



}
