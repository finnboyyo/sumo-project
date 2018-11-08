using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour {
	[SerializeField]bool beenHit;
	// Use this for initialization
	void Start () {
		GetComponent<Collider> ().isTrigger = true;
	}
	
	void OnTriggerStay (Collider other) {
		if (beenHit == false) {
			beenHit = true;
			Reaction (other);
		} 
	}

	void Reaction (Collider other) {
		Debug.Log (other.gameObject.name);
	}
	void OnEnable (){
		Debug.Log ("yo");
		beenHit = false;
	}
}
