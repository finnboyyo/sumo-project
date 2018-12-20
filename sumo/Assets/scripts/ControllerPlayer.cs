using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;


[RequireComponent(typeof(Rigidbody)) ]
public class ControllerPlayer : MonoBehaviour {
	public string name;
	int fullHealth = 10;
	public int currentHealth;
	[SerializeField] bool isPlayer = false;
	Rigidbody phat;
	Animator animator;
	[SerializeField] bool canRoll = true;
	public float speed = 1;

	CharacterDirection theDirection = CharacterDirection.up;
	Vector3[] rotations = {
		new Vector3 (0, 0, 0), new Vector3 (0, 180, 0), new Vector3 (0, 90, 0), new Vector3 (0, -90, 0)
	};
	[SerializeField]Transform hitboxPivot;
	[SerializeField]Hitbox hitbox;
	float buffer = 0.05f;
	SumoAI sumoAI;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		hitbox = GetComponentInChildren<Hitbox> ();
        phat = GetComponent<Rigidbody>();
		sumoAI = GetComponent<SumoAI> ();
	// tell winner script that were inthe ring
		winner.playersInTheRing.Add (this);
		currentHealth = fullHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayer == true) {
			Movevment ();
			if (Input.GetButtonDown ("Fire1")) {
				attack ();

			}

		} else {
			sumoAIMovevment ();
		}
	}
	public void attack () {
		hitbox.ActivateHitbox ();
		// Cant spam rolls after a push. Bugs?
		canRoll = false;
		StartCoroutine (coolDownForRoll ());
	}

	public void OutOfBounds () {
		winner.playersInTheRing.Remove (this);
		this.enabled = false;
	}
     void Movevment()
    {
        phat.velocity = Input.GetAxis("Horizontal") * speed * Vector3.right;
		GetDirection ();
	
		phat.velocity += Input.GetAxis("Vertical") * speed * Vector3.forward;
		animator.SetFloat ("movement", phat.velocity.magnitude);
		//Debug.Log (phat.velocity);
		//Debug.Log (phat.velocity.magnitude);

	} 
	void sumoAIMovevment()
	{
		phat.velocity = sumoAI.Where ().normalized * speed;
		GetAIDirection ();
	} 

	void RollStart (){


	}

	public void GotHit (Vector3 direction,float pushStrength = 2000f)
	{
		phat.AddForce((direction * -pushStrength * (fullHealth/currentHealth)));
		if (currentHealth > 1) {
			currentHealth--;
		}
	}
	void GetDirection (){ 
		if (Input.GetAxis ("Horizontal") > buffer) {
			theDirection = CharacterDirection.right;
			hitboxPivot.localEulerAngles = rotations [2];
			animator.SetFloat ("direction", (float)theDirection);

			} 
		if (Input.GetAxis ("Horizontal") < -buffer) {
			
			theDirection = CharacterDirection.left;
			hitboxPivot.localEulerAngles = rotations [3];
			animator.SetFloat ("direction", (float)theDirection);
		} 
		if (Input.GetAxis ("Vertical") < -buffer) {
			
			theDirection = CharacterDirection.down;
			hitboxPivot.localEulerAngles = rotations [1];
			animator.SetFloat ("direction", (float)theDirection);
		}  if (Input.GetAxis ("Vertical") > buffer) 
	
		{
			theDirection = CharacterDirection.up;
			hitboxPivot.localEulerAngles = rotations [0];
			animator.SetFloat ("direction", (float)theDirection);
		}

	} 


	void GetAIDirection (){ 

		if ((Mathf.Abs(sumoAI.Where ().normalized.x) > (Mathf.Abs (sumoAI.Where ().normalized.y)))) {
			if (Mathf.Abs(sumoAI.Where ().normalized.x) > (sumoAI.Where ().normalized.x)) {
				theDirection = CharacterDirection.right;
				hitboxPivot.localEulerAngles = rotations [2];
				transform.localScale = new Vector3 (1, 1, 1);
				animator.SetFloat ("direction", (float)theDirection);

			} 
		
			else  {
				theDirection = CharacterDirection.left;
				hitboxPivot.localEulerAngles = rotations [3];
				//transform.localScale = new Vector3 (-1, 1, 1);
				animator.SetFloat ("direction", (float)theDirection);
				}
		} else {
			if (Mathf.Abs(sumoAI.Where ().normalized.y) > (sumoAI.Where ().normalized.y)) {

				theDirection = CharacterDirection.down;
				hitboxPivot.localEulerAngles = rotations [1];
				animator.SetFloat ("direction", (float)theDirection);
			}  
			else  {

				theDirection = CharacterDirection.up;
				hitboxPivot.localEulerAngles = rotations [0];
				animator.SetFloat ("direction", (float)theDirection);
			}
		}

	} 

	IEnumerator coolDownForRoll(float pushTime = 1f){
		yield return new WaitForSeconds (pushTime + .2f);
		canRoll = true;

	}


}
