using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatArea : MonoBehaviour {

	void OnTriggerStay (Collider other){
		if (other.gameObject.GetComponent <SumoAI> () != null) {
			other.gameObject.GetComponent <SumoAI> ().underThreat = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.gameObject.GetComponent <SumoAI> () != null) {
			other.gameObject.GetComponent <SumoAI> ().underThreat = false;
		}
	}

}
