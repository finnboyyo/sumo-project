using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using UnityEngine.UI;


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
	[SerializeField]bool movingOutOfTheWay =false;
	Vector3[] escapeDirections = new Vector3[4];
	// Use this for initialization
	Vector3 fleeDirection;
	[SerializeField] float fleeDuration = 2f;

	public Vector3 Where (){
		float distanceToCenter = Vector3.Distance (transform.position, (ring.transform.position + offset));
		//Debug.Log (distanceToCenter);
		float opponentsDistanceToCenter = Vector3.Distance (opponent.transform.position, (ring.transform.position + offset));
		//Debug.Log (playersDistanceToCenter);
		Vector3 directionToGo = new Vector3 (0, 0, 0); 
		if (movingOutOfTheWay) {
			 


			return fleeDirection;

		} else {
			if (opponentsDistanceToCenter > distanceToCenter) {
				//try and push the opponent out
				ClosestPlayer ();
				Debug.Log ("try and push the opponent out");
				directionToGo = opponent.transform.position - transform.position;

			} else {
				//try to go to the center
				Debug.Log ("try to go to the center");
				directionToGo = (ring.transform.position + offset) - transform.position;

				if (underThreat == true) {
					//try and get out of the threat zone
					Debug.Log ("try and get out of the threat zone");
					fleeDirection = pathToFlee ();
					StartCoroutine (WhereImRunning ());
					movingOutOfTheWay = true;

					return fleeDirection;
				}

			}


			return directionToGo.normalized;
		}
	}
	Vector3 pathToFlee (){
		int i = Random.Range (0, 3);
		if (Vector3.Distance (transform.position, escapeDirections[i]) > ringRadius) {
				//if (Vector3.Distance (transform.position, point) < ((ringRadius / 2) * 3)) {
			return escapeDirections[i];
		} else {		
			return new Vector3(0,.5f,0);
		}		
	}
	public Vector3 DirectionToClosestPlayer (){
		return (opponent.transform.position - transform.position);
	}
	public void ClosestPlayer (){
		float distanceFromUs = ringRadius * 2;
		//Vector3 directionToNearestPlayer = new Vector3 ();
		foreach (ControllerPlayer opp in winner.playersInTheRing) {
			float distanceFromPlayer = Vector3.Distance (transform.position, (opp.transform.position));
			if (distanceFromPlayer < distanceFromUs) {
				distanceFromUs = distanceFromPlayer;
				if ((opp.transform.position - transform.position) != Vector3.zero) {
					//directionToNearestPlayer = (opp.transform.position - transform.position);
					opponent = opp.gameObject;
				}
			}

		}
		//return directionToNearestPlayer;
	}
	void Start () {
		controllerPlayer = GetComponent <ControllerPlayer> ();
		ringRadius = ring.GetComponent<Collider> ().bounds.max.x / 2;
		escapeDirections [0] = new Vector3( ringRadius*2, .5f, 0 );
		escapeDirections [1] = new Vector3( -ringRadius*2, .5f, 0 );
		escapeDirections [2] = new Vector3( 0, .5f, ringRadius*2 );
		escapeDirections [3] = new Vector3(0,.5f, -ringRadius*2 );
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
				StartCoroutine (AttackCooldown ());
			}
		}
	}
	IEnumerator AttackCooldown () {
		yield return new WaitForSeconds (attackDelay + Random.Range (0f,0.2f));
		readyToAttack = true;
	}
	IEnumerator WhereImRunning () {
		

		Debug.Log (fleeDirection);
		yield return new WaitForSeconds (fleeDuration);
		movingOutOfTheWay = false;
		Debug.Log ("done fleeing");
	}
}
