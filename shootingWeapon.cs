using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Eddie Huang
 * this is to shoot the weapon 
 * by setting the time intervels the shooting motion will synchronize with the player's animation 
 * the enemies only will be shoot if the player clicks on them 
 * by giving the range of 10 and the layermask , the player can shoot the enemy within clicks on its positio 
 * same technique as the assignment5 painting 
 * 
 */

public class shootingWeapon : MonoBehaviour {
	public float range = 10f;
	public int damage = 10;
	private Ray shootRay; // this is to create a ray to detect if the stuff has been  shot 
	private RaycastHit shootHit;
	private int shootableMask;
	 

	void Awake () {
		shootableMask = LayerMask.GetMask ("Shootable");
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
	 

	}
	
	// Update is called once per frame
	void Update () {
 

		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);



		shootRay = Camera.main.ScreenPointToRay (mousePos);
		if (Physics.Raycast (shootRay, out shootHit, range, shootableMask)) {
			Debug.Log("hit something");
			if (shootHit.collider.tag == "Enemy") {
				
				enemyHealthController enemyHealth = shootHit.collider.GetComponent<enemyHealthController> ();
				if (enemyHealth != null) {

					Debug.Log("hit enemy");
					enemyHealth.enemeyGetDamage (damage);


				}
			}



		
		}


		 

	}
}
