﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed, damage;

	private GameObject currentTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}


	void OnTriggerEnter2D (Collider2D collider){
		Debug.Log (name + "has triggered");
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Health health = collider.gameObject.GetComponent<Health>();
		if (attacker && health) {
				health.DealDamage(damage);
				Destroy (gameObject); // destroys projectile
			}
		}
	}
