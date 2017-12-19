using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Author: Eddie Huang
   sepcial thanks deliver to teacher Ryan ,  through his instruction , i could possibly set tthe invisible wall and obstruct the players motion back to the end of the camera 
 *since the camera has been set properly so i do not tend to make the parallax scrolling 
 *sorry that i almost run out of time to do so 
 */

public class cameraController : MonoBehaviour {

	public Transform target;  // this is to trace the target position 
	public float smoothDistance = 10.0f; // the smooth position that the camera moves 
	private float offsetOfYAxis; // the offset of the camera in y axis 
	private float offsetOfXAxis;  // this offset of the camera in x axis 

	public Transform invisibleWall;

 
	void Start () {
		offsetOfYAxis = target.position.y -  transform.position.y + 4f ;
		offsetOfXAxis =  target.position.x - transform.position.x ;
	 // this is the offset positoin of the axis 
	}
	
    // the update of the camera motion 
	void FixedUpdate () {
		Vector3 targetCameraPosition;  // set the camera position with the vector 
		 
		targetCameraPosition.y = target.transform.position.y + offsetOfYAxis ; // this is to set the offset when the player jumps and falls which follows the camera 
		targetCameraPosition.z = -10f; 
		// this is to set the distance of the invisble wall of the camera between player and the end edge of the screen 
		// the precise distance is set to be 4.5 
 if (target.position.x - 11f >= invisibleWall.position.x) { 
			targetCameraPosition.x = target.transform.position.x + offsetOfXAxis ;     // if the target position - the distance is greater than the distance between the invisible wall , move camera 
		// invisibleWall.transform.position = new Vector3 (target.position.x - 11f + offsetOfXAxis  , invisibleWall.transform.position.y, invisibleWall.transform.position.z); // then adjust the position of the invisible wall 
			// this statement does not work so i comment this out 
			transform.position = Vector3.Lerp (transform.position, targetCameraPosition,   Time.deltaTime);
			// the smooth position has to be set as Time.deltatiME 
		}   else {
			 
		 	targetCameraPosition.x = transform.position.x + offsetOfXAxis ;       // this is the target position of the camera 
			transform.position = Vector3.Lerp (transform.position, targetCameraPosition, smoothDistance * Time.deltaTime);
		}
	 
		  
		 
		 

		       // the z index of the camera remains the same as -5 
	
	 	
          // the transform has been lerp smoothly 


	}
}
