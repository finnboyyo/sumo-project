﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneMan {


	public static int playersActive;
	//Tarter Suace means Start game 
	public static void TarterSause()
	{
		SceneManager.LoadSceneAsync (1);
		playersActive = 4; 
		Debug.Log (playersActive);
	} 
	// Ranch means restart

	public static void Ranch()
	{

		playersActive = 4; 
		Debug.Log (playersActive);
		SceneManager.LoadSceneAsync (0);

	

	}


	public static void PlayerOut ()
	{
	
		playersActive--;
		if (playersActive == 1) 
		{
			//Remaining Player WWWWINNN 
		}
		if (playersActive == 0) 
		{
			//Well thats a shame
		}
	}

}