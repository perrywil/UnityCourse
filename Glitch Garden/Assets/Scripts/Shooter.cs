﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;


	void Start () {
		animator = GetComponent<Animator>();

		// creates a parent if necessary
		projectileParent = GameObject.Find("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}

		SetMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	// Look through all spawners, and set myLaneSpawner if found
	void SetMyLaneSpawner () {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			// current Shooter.transform.position.y does not need Shooter in it since we are already in this object
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner; // it equals "spawner" form this foreach loop
				return;
			}
				Debug.LogError(name + "does not have a Spawner in current lane");
		} 
		//Shooter.transform.position.y = thisLane;
	}

	bool IsAttackerAheadInLane () {
		// Exit if no attackers in lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		// if there are attackers, are they ahead
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		// Attackers in lane, but behind us
		return false;
	}


	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	// Cant use OnBecameInvisible () because the sprite renderer is in the body not on the parent
}
