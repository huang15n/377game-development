using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Eddie Huang
 * the audio controller is set to controll the audio display of the player 
 * there are walk , run , jump, backwalk , collectibles sounds 
 * 
 *
 */
 
public class CharacterAudioController : MonoBehaviour {
	public AudioClip[] officerAudioClips;
	private AudioSource officerAudioSource;
	// Use this for initialization
	private void Awake () {
		officerAudioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	private void walkSound(){

		officerAudioSource.PlayOneShot (officerAudioClips[0]);

	}


	private void runSound(){

		officerAudioSource.PlayOneShot (officerAudioClips[1]);

	}


	private void jumpSound(){

		officerAudioSource.PlayOneShot (officerAudioClips[2]);
	}

	private void backWalkSound(){
		officerAudioSource.PlayOneShot (officerAudioClips[3]);

	}


	public void collectableSound(){

		officerAudioSource.PlayOneShot (officerAudioClips[4]);

	}


	public void teleportSound(){

		officerAudioSource.PlayOneShot (officerAudioClips[5]);

	}

	public void healthSound(){

		officerAudioSource.PlayOneShot (officerAudioClips[6]);

	}

	public void reloadSound(){

		officerAudioSource.PlayOneShot (officerAudioClips[7]);
	}


}
