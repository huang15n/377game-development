using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Author: Eddie Huang 
 *this script to make the smooth transition between different scenes 
 *the scene text is defined by the name of the scene which corresponding to different text 
 *the trick for the keyboard typing is that i set the timer and the wordcount of the string that i want to display 
 *with time interval i concatenate each character and make it feel like it is typing along with the keyboard audios 
 *
 */

public class SceneLoadingScript : MonoBehaviour {

	private string prelude1 = "December, 2017.  A series of bizarre muders occur on the campus of Univeristy. Officer Brad is assigned to investigated to the case.  With further discoveries, Officer Brad found the secrete lab is running by biology students, which results in the biological virus explosion,  Brad has to manage to run out of the campus and reveal the undercovers to the public. \n Be Safe";
	private string prelude2 = "The events of virus explosition in Biology building has been discovered.So Brad decided to go to Odette Building to get a way to escape. There are still many creatures remained unknown. Using a means of weapons to get Brad saved and get to destination\n Good luck!";
	private string prelude3 = "Brad attempted to escape from Odette Building but ran into a giant mutatnt monster that interupted his plan. To make his way to the safe place, he has to come across residential area and manages the escape. Whether success or not, you make the choice. \n Last Chance";
	private string prelude4 = "With the only short time left , the mutant is destroyed by rocket launcher. Although Brad sucessfully escaping the city via the helicopher, the guovernment gains the concern over the massive virus explosion and decided to employe the thermobaric missile strike to vaporize the whole area and its nfected populace. The truth prevails ultimately. ";
	public Text preludeText;

	public Text title;

	private int i;
	private float timer;

	public Button next;
	Scene currentScene;
	 
	// Update is called once per frame

	void Awake(){
		i = 0;
		timer = 0.0f;
		currentScene = SceneManager.GetActiveScene ();

	}


	void Update () {
		
		if (currentScene.name == "LoadingScene1") {
			title.text = "Chapter One";
			if (i < prelude1.Length && timer < prelude1.Length) {

			 
				preludeText.text += prelude1 [i];
				i++;
				timer += Time.deltaTime;
			 
		   
			}
		}



		if (currentScene.name == "LoadingScene2") {
			title.text = "Chapter Two";
			if (i < prelude2.Length && timer < prelude2.Length) {


				preludeText.text += prelude2 [i];
				i++;
				timer += Time.deltaTime;


			}
		}

		if (currentScene.name == "LoadingScene3") {
			title.text = "Chapter Three";
			if (i < prelude3.Length && timer < prelude3.Length) {


				preludeText.text += prelude3 [i];
				i++;
				timer += Time.deltaTime;


			}
		}
	

		if (currentScene.name == "LoadingScene4") {
			title.text = "";
			if (i < prelude4.Length && timer < prelude4.Length) {


				preludeText.text += prelude4 [i];
				i++;
				timer += Time.deltaTime;


			}
		}



		
	}


}
