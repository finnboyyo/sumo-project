using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundery : MonoBehaviour {
	[SerializeField]Timer timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerExit(Collider other)
    {
		if (other.CompareTag("Player") ) 
		{

			other.gameObject.GetComponent<ControllerPlayer> ().OutOfBounds ();
			if (other.gameObject.GetComponent<SumoAI>() != null) {
				other.gameObject.GetComponent<SumoAI> ().enabled = false;

			}
			if (winner.CheckPlayerCount ()) {
				timer.isTimerRunning = false;
			}
		}
		SceneMan.playersActive--;

		Debug.Log(SceneMan.playersActive);

		if (SceneMan.playersActive == 1) { SceneMan.Ranch ();
		};
    }


}
