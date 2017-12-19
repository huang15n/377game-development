using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Eddie Huang
 *this is to make the laser gun script 
 *when the laser gun contacts with the enemies , it causes immediate death 
 *i still failed to make the line renderer to be generated as the desired position 
 * to make things up , i had to change the shooting position y to the position 2 . this part, i admit that i am unable to solve 
 * 
 */

public class lasergunScript : MonoBehaviour {

	public float range = 30f;
 
 
	private int shootableMask;

	private playerController orientation;
	private GameObject  player;
	private LineRenderer gunLine;


	void Awake () {
		shootableMask = LayerMask.GetMask ("Shootable");
		gunLine = GetComponent<LineRenderer> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		orientation = player.GetComponent<playerController> ();

	}

	// Update is called once per frame
	void Update () {
		
		Vector3 mouseRay = new Vector3 (Input.mousePosition.x, 2f, 0f);


		RaycastHit []hits;

		Ray ray= Camera.main.ScreenPointToRay (mouseRay);
	

		//Vector3 rot;

	
		 

		ray.origin = transform.position;

		ray.direction = mouseRay;
		int face = 1;
		if (mouseRay.x > player.transform.position.x && orientation.getOrientation () == -1) {

		 gunLine.SetPosition (0, ray.origin + ray.direction * -range);
			face = -1;
		} else if (mouseRay.x > player.transform.position.x && orientation.getOrientation () == 1) {

		 gunLine.SetPosition (0, ray.origin + ray.direction * range);
			face = 1;
		}

		hits = Physics.RaycastAll (ray.origin, ray.direction * face , range   );
		for(int i = 0; i < hits.Length; i++){

	 

			if (hits[i].collider.tag == "Enemy") {
				Debug.Log ("shoot it");
				enemyHealthController enemyHealth = hits[i].collider.GetComponent<enemyHealthController> ();
 

					Debug.Log("hit enemy");
					enemyHealth.enemyDeath();


			 
		 

			}
		




		}




	}
}
