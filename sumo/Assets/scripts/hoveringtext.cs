using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoveringtext : MonoBehaviour {
	[SerializeField] GameObject mainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (mainCamera.transform.position);
		transform.Rotate (new Vector3 (0, 180, 0));	
	}
}
