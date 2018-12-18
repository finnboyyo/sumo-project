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
	public bool underThreat = false;
	bool movingOutOfTheWay =false;
	public Transform [] escapeDirections;
	// Use this for initialization
	Vector3 fleeDirection;

	public Vector3 Where (){
		if (movingOutOfTheWay == false) {
			float distanceToCenter = Vector3.Distance (transform.position, (ring.transform.position + offset));
			//Debug.Log (distanceToCenter);
			float opponentsDistanceToCenter = Vector3.Distance (opponent.transform.position, (ring.transform.position + offset));
			//Debug.Log (playersDistanceToCenter);
			Vector3 directionToOpponent = new Vector3 (0, 0, 0); 
			if (distanceToCenter > ringRadius) {

				if (opponentsDistanceToCenter > distanceToCenter) {
					directionToOpponent = opponent.transform.position - transform.position;
				} else {
					directionToOpponent = (ring.transform.position + offset) - transform.position;

					if (underThreat == true) {
						StartCoroutine (whereImRunning ());
						movingOutOfTheWay = true;

				
					}

				}
			}
			return directionToOpponent.normalized;
		} else {
			return fleeDirection.normalized;
		}
	}
	Vector3 pathToFlee (){
		Vector3[] theWayToGo = new Vector3[4];
		float[] theirDistance = new float [4];
		for (int i = 0; i >= 4; i++) {
			theirDistance [i] =  Vector3.Distance (transform.position, escapeDirections[i].position);
		}
		float maxThreshold = ringRadius*2;
		for (int i = 0; i >= 4; i++) {
			if (theirDistance [i] < maxThreshold) {
				theWayToGo [3 - i] = escapeDirections [i].position; 
				maxThreshold = theirDistance [i];
			} else {
				for (int j = 1; j >= 4; j++) {
					theWayToGo [j - 1] = theWayToGo [j];
				}
				theWayToGo [3] = escapeDirections [i].position;
			}

		}return theWayToGo [3];
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
		yield return new WaitForSeconds (attackDelay + Random.Range (0f,0.2f));
		readyToAttack = true;
	}
	IEnumerator whereImRunning () {
		float startTime = Time.time;
		fleeDirection = pathToFlee ();
		Debug.Log (fleeDirection);
		while ((Time.time - startTime)<= 1f) {

			Debug.Log ("stuff");
			yield return null;

		}
		movingOutOfTheWay = false;
	}
}
