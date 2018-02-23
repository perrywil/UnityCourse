using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Attacker attacker;
	private Animator anim;

	// Use this for initialization
	void Start () {
		attacker = GetComponent<Attacker>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		GameObject obj = collider.gameObject;

		// leave the method if not colliding with defender
		if (!obj.GetComponent<Defender> ()) {
			return;
		}

		if (obj.GetComponent<Stone> ()) {
			anim.SetTrigger ("Jump trigger");
		} else {
			anim.SetBool ("isAttacking", true);
			attacker.Attack(obj);
		}

		Debug.Log (name + "collided with " + collider);
	}
}
