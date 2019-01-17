using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class winner {
	public static List <ControllerPlayer> playersInTheRing = new List<ControllerPlayer> ();
	public static List <ControllerPlayer> winners = new List<ControllerPlayer> ();
	public static string winName;


	public static bool CheckPlayerCount () {
		if (playersInTheRing.Count == 1) {
			MatchOver ();
			return true;
		} 
		else {
			return false;
		}
	}

	public static void resetText (){
	
		winName = "";
	
	}

	public static void MatchOver () {//int highestHealth = 0;
		//foreach (ControllerPlayer player in playersInTheRing) {
		//if (player.currentHealth > highestHealth) {
		//highestHealth = player.currentHealth;
			
		

		//foreach (ControllerPlayer player in playersInTheRing) {
		//if (player.currentHealth == highestHealth) {
		//winners.Add (player);
			



		if (playersInTheRing.Count == 1) {
			if (playersInTheRing [0].GetComponent<ControllerPlayer> ().name == "you") {
					SceneMan.Win ();
				} else {
					SceneMan.Lose ();
				}

				//winName = winners [0].name + " wins";

				//Debug.Log (winners[0].name);
		
			} else {
				SceneMan.Draw ();
			}



			//winName = "Better luck next time";


		}
	}

	

