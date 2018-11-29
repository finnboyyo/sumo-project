using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class winner {
	public static List <ControllerPlayer> playersInTheRing = new List<ControllerPlayer> ();
	public static List <ControllerPlayer> winners = new List<ControllerPlayer> ();

	public static bool CheckPlayerCount () {
		if (playersInTheRing.Count == 1) {
			MatchOver ();
			return true;
		} 
		else {
			return false;
		}
	}

	public static void MatchOver () {int highestHealth = 0;
		foreach (ControllerPlayer player in playersInTheRing) {
			if (player.currentHealth > highestHealth) {
				highestHealth = player.currentHealth;
			}
		
		}
		foreach (ControllerPlayer player in playersInTheRing) {
			if (player.currentHealth == highestHealth) {
				winners.Add (player);
			}

		}
		Debug.Log (winners.Count);
		if (winners.Count == 1) {
			Debug.Log (winners[0].name);
		} else {Debug.Log ("it's a draw");
		}
	}

}
