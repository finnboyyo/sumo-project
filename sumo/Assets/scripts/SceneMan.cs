using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneMan {


	public static int playersActive;
	//Tarter Suace means Start game 
	public static void TarterSause()
	{
		playersActive = 4;
		SceneManager.LoadScene (1);
		Debug.Log (playersActive);
	} 
	// Ranch means restart

	//public static void Ranch()
	//{

	//playersActive = 4; 
		//Debug.Log (playersActive);

	//SceneManager.LoadSceneAsync (0);

	

	//}
	public static void Win()
	{
		winner.playersInTheRing.Clear ();
		SceneManager.LoadScene (3);
	}
	public static void Lose()
	{
		SceneManager.LoadScene (2);
	}
	public static void Draw()
	{
		SceneManager.LoadScene (4);
	}
	public static void PlayerOut ()
	{
	
		playersActive--;
		if (playersActive == 1) {
			//Remaining Player WWWWINNN 
		}
		if (playersActive == 0) {
			//Well thats a shame
		}
	
		
	}
}
