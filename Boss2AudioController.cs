using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 *this script is to set the boss2's audio 
 *but i think i failed to do so because the audio does not display well as i expected 
 *
 */

public class Boss2AudioController : MonoBehaviour {

 

	private AudioSource bossAS;
	public AudioClip [] bossClips;

	private void Awake(){

		bossAS = GetComponent<AudioSource> ();


	}



	private void roaring(){

		bossAS.PlayOneShot (bossClips[0]);

	}


	private void stomp(){

		bossAS.PlayOneShot (bossClips[1]);

	}

	private void hit2(){
		bossAS.PlayOneShot (bossClips[2]);

	}
 
}
