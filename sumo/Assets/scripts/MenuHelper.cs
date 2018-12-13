using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelper : MonoBehaviour {

	//Stan the man is start 

	public void StanTheMan ()
	{

		SceneMan.TarterSause ();

	}
	public void QuitGame(){
	
		Debug.Log ("Quit");
		Application.Quit();
	}



}
