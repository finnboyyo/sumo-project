using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {
	[SerializeField]bool beenHit;

	Renderer rend;
	bool isAttacking = false;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		GetComponent<Collider> ().isTrigger = true;
		rend.enabled = false;}
	
	void OnTriggerStay (Collider other) {
		if (other.CompareTag("Player")&& isAttacking) {
			if (beenHit == false) {
				beenHit = true;
				Reaction (other);
			}
		}
	}

	void Reaction (Collider other) {
		other.gameObject.GetComponent<ControllerPlayer> ().GotHit (transform.forward);
	}
	void OnEnable (){
		beenHit = false;
	}
	public void ActivateHitbox () {
		StartCoroutine (HitboxActivation ());
		rend.enabled = true;

	}
	
	IEnumerator HitboxActivation () {
		isAttacking = true;
		beenHit = false;
		yield return new WaitForSeconds (0.3f);
		rend.enabled = false;
		isAttacking = false;
	}
}
