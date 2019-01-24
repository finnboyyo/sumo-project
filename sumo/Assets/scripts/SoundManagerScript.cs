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
		explosionSound = Resources.Load<AudioClip> ("explode");
		audioSrc = GetComponent<AudioSource>();
	}
	

	public static void PlaySound (string clip)
	{
		switch (clip) {
		case "hit":
			audioSrc.PlayOneShot (hitSound);
			break;
		case "beenhit":
			audioSrc.PlayOneShot (beenHitSound);
			break;
		case "explosion":
			audioSrc.PlayOneShot (explosionSound);
			break;

		}
	}
	}

