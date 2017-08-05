using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventStuff : EventTrigger {

	Rigidbody rb;
	GameObject obj;
	void Start() {
		rb = GetComponent<Rigidbody> ();
//		obj = GameObject.Find ("BlankBlock");
//		obj.AddComponent<Rigidbody> ();
//		obj.GetComponent<Rigidbody> ().useGravity = false;
//		obj.GetComponent<Rigidbody> ().MovePosition (new Vector3 (15, 15, 15));
//		obj.SetActive (true);

	}

	void Update() {
		Quaternion q = new Quaternion ();
		q.eulerAngles = new Vector3 (0, 0, 0);
		rb.MoveRotation (q);
		Debug.Log ("Updating");
	}

	public override void OnPointerClick(PointerEventData data) {
		Quaternion q = new Quaternion ();
		q.eulerAngles = new Vector3 (0, 0, 0);
		rb.MoveRotation (q);
		Debug.Log ("Clicked");
	}
		
}