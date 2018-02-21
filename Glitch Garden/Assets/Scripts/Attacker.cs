using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)] public float walkSpeed;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		// move enemy left
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D (){
		Debug.Log(name + "has triggered");
	}
}
