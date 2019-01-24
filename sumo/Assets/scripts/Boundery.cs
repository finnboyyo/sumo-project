using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Boundery : MonoBehaviour {
	public TextMeshProUGUI containText;

	[SerializeField]Timer timer;
	// Use this for initialization



	void Start () {

		winner.resetText ();

		//containText.text = winner.winName;	
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
				//Debug.Log (other.name + "got knocked out");
				other.gameObject.GetComponent<SumoAI> ().enabled = false;

			}
			if (winner.CheckPlayerCount ()) {
				timer.isTimerRunning = false;

			
			
			}

		}
		SceneMan.playersActive--;



		/*if (SceneMan.playersActive == -1) { SceneMan.Ranch ();

			//StartCoroutine (timeBuffer());
		};*/
    }


	IEnumerator timeBuffer ()
	{

		yield return new WaitForSecondsRealtime (5f); 

		winner.playersInTheRing.Clear ();

		SceneManager.LoadSceneAsync (0);
	
	}

}
