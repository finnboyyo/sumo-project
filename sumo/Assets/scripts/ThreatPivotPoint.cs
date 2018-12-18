using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreatPivotPoint : MonoBehaviour {
	Vector3 offset = new Vector3 (0, .5f, 0);
	[SerializeField] GameObject ring;
	Vector3 centerOfTheRing;

	void Start (){
		centerOfTheRing = ring.transform.position + offset;
	}


	
	// Update is called once per frame
	void Update () {
		transform.LookAt (centerOfTheRing);
	}
}
