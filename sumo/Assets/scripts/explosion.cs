using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion: MonoBehaviour {
	float timeToExplode = 0.01f;
	[SerializeField] ParticleSystem boom;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void ExplosionTime () {
		StartCoroutine (WaitToExplode ());
		
	}
	IEnumerator WaitToExplode (){
		yield return new WaitForSeconds (timeToExplode);
		SoundManagerScript.PlaySound ("explosion");
		boom.Play ();
	}

	}

