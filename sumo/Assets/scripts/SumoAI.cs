using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class SumoAI : MonoBehaviour {
	[SerializeField] GameObject opponent;
	[SerializeField] GameObject ring;
	Vector3 offset = new Vector3 (0, .5f, 0);
	ControllerPlayer controllerPlayer;
	float closeEnoughToHit = 1f;
	float attackDelay = 0.2f;
	bool readyToAttack = true;
	float ringRadius;
	// Use this for initialization

	public Vector3 Where (){
		float distanceToCenter = Vector3.Distance (transform.position, (ring.transform.position+ offset));
		//Debug.Log (distanceToCenter);
		float opponentsDistanceToCenter = Vector3.Distance (opponent.transform.position, (ring.transform.position + offset));
		//Debug.Log (playersDistanceToCenter);
		Vector3 directionToOpponent = new Vector3 (0, 0, 0); 
		if (distanceToCenter > ringRadius) {

			if (opponentsDistanceToCenter > distanceToCenter) {
				directionToOpponent = opponent.transform.position - transform.position;
			} else {
				directionToOpponent = (ring.transform.position + offset) - transform.position;
			}
		}
		return directionToOpponent.normalized;
	}
	public Vector3 ClosestPlayer (){
		float distanceFromUs = ringRadius * 2;
		Vector3 directionToNearestPlayer = new Vector3 ();
		foreach (ControllerPlayer opp in winner.playersInTheRing) {
			float distanceFromPlayer = Vector3.Distance (transform.position, (opp.transform.position));
			if (distanceFromPlayer < distanceFromUs) {
				distanceFromUs = distanceFromPlayer;
				if ((opp.transform.position - transform.position) != Vector3.zero) {
					directionToNearestPlayer = (opp.transform.position - transform.position);
					opponent = opp.gameObject;
				}
			}

		}
		return directionToNearestPlayer;
	}
	void Start () {
		controllerPlayer = GetComponent <ControllerPlayer> ();
		ringRadius = ring.GetComponent<Collider> ().bounds.max.x / 2;
		ClosestPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
		ShouldWeAttack ();
		ClosestPlayer ();
	}
	void ShouldWeAttack () {
		if (readyToAttack == true){
			if (Where ().magnitude >= closeEnoughToHit) {
				controllerPlayer.attack ();
				readyToAttack = false;
				StartCoroutine (attackCooldown ());
			}
		}
	}
	IEnumerator attackCooldown () {
		Debug.Log ("did it");
		yield return new WaitForSeconds (attackDelay + Random.Range (0f,0.2f));
		readyToAttack = true;
		Debug.Log ("ready");
	}
}
