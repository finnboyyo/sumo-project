using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour {

    Animator animator;
    bool currentState;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
       currentState = animator.GetBool("isLeft");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Horizontal") == true)
        {
         
        currentState = !currentState;
            animator.SetBool("isLeft", currentState) ;
            
        }  

	}
}
