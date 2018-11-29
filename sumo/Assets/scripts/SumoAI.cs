﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class SumoAI : MonoBehaviour {
	[SerializeField] GameObject opponent;
	[SerializeField] GameObject ring;
	Vector3 offset = new Vector3 (0, .5f, 0);


	// Use this for initialization

	public Vector3 Where (){
		float distanceToCenter = Vector3.Distance (transform.position, (ring.transform.position+ offset));
		//Debug.Log (distanceToCenter);
		float playersDistanceToCenter = Vector3.Distance (transform.position, (ring.transform.position + offset));
		//Debug.Log (playersDistanceToCenter);
		Vector3 directionToPlayer = new Vector3 (0, 0, 0); 
		if (distanceToCenter > (ring.GetComponent<Collider> ().bounds.max.x / 2)) {

			if (playersDistanceToCenter > distanceToCenter) {
				directionToPlayer = opponent.transform.position - transform.position;
			} else {
				directionToPlayer = (ring.transform.position + offset) - transform.position;
			}
		}
		return directionToPlayer.normalized;
	}
	public Vector3 ClosestPlayer (){
		float distanceFromUs = 0f;
		Vector3 directionToNearestPlayer = new Vector3 ();
		foreach (ControllerPlayer player in winner.playersInTheRing) {
			float distanceFromPlayer = Vector3.Distance (transform.position, (player.transform.position));
			if (distanceFromPlayer > distanceFromUs) {
				directionToNearestPlayer =(player.transform.position - transform.position).normalized;
			}

		}
		return directionToNearestPlayer;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Where ();
	}
}
