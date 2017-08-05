using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// Update is called once per frame
	private Rigidbody rb;
	private Transform tr;
	void Update () {
		
	}

	void Start(){
		rb = GetComponent<Rigidbody> ();
		tr = GetComponent<Transform> ();
	}
	//called before any physics calucations
	void FixedUpdate (){
		
		float moveHorizontal = (Input.GetAxis ("Horizontal")) * 100;
		float moveVertical = (Input.GetAxis ("Vertical")) * 100;
		float mouseX = Input.GetAxis ("Mouse X");
		float mouseY = Input.GetAxis ("Mouse Y");
		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement);
		Vector3 look = new Vector3 (0, mouseX, 0);
		tr.Rotate (look);


	}
}