using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
	public static AudioClip hitSound, beenHitSound, explosionSound;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
		hitSound = Resources.Load<AudioClip> ("hit");
		beenHitSound = Resources.Load<AudioClip> ("beenhit");
		explosionSound = Resources.Load<AudioClip> ("explosion");
		audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {}
		public static void PlaySound (string clip)
		{
			switch (clip){
			case "hit":
				audioSrc.PlayOneShot (hitSound);
				break;
			case "beenHit":
				audioSrc.PlayOneShot (beenHitSound);
				break;
			case "explosion":
				audioSrc.PlayOneShot (explosionSound);
				break;

			}
		}
	}

