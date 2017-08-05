using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollScript : MonoBehaviour {
	private GameObject player;
	private Rigidbody rb;
	private Transform tr;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("FirstPersonCharacter");
		rb = GetComponent<Rigidbody> ();
		tr = GetComponent<Transform> ();
		transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	/*
	void Update () {
		Vector3 movement = player.transform.position;
		rb.AddForce (movement);
		Vector3 look = player.GetComponent<Vector3> ();
		tr.Rotate (look);
	}*/

	void FixedUpdate()
	{
		transform.localPosition = new Vector3 (0f,-1f, 0f);
		//Vector3 movement = player.transform.position;
		//rb.AddForce (movement);
		//Vector3 look = player.GetComponent<Vector3> ();
		//tr.Rotate (look);
	}
}
