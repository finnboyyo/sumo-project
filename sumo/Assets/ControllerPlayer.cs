using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody)) ]
public class ControllerPlayer : MonoBehaviour {
    Rigidbody phat;
    public float speed;
	// Use this for initialization
	void Start () {

        phat = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        Movevment();
        
	}

    void Movevment()
    {
        phat.velocity = Input.GetAxis("Horizontal") * speed * Vector3.right;

        phat.velocity += Input.GetAxis("Vertical") * speed * Vector3.forward;

    } 
}
