using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)] public float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	// Use this for initialization
	void Start () {
		// RigidBody was added in unity directly
		//Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
		//myRigidbody.isKinematic = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		// move enemy left
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			anim.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D (){
		//Debug.Log(name + "has triggered");
	}

	public void setSpeed (float speed) {
		currentSpeed = speed;
	}

	// Called from the animator at the time of actuall attack
	public void StrikeCurrentTarget (float damage) {
		//Debug.Log (name + " is making damage " + damage);
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health> ();
			if (health) {
				health.DealDamage(damage);
			}
		}
	}

	public void Attack (GameObject obj){
		currentTarget = obj;
	}
}
