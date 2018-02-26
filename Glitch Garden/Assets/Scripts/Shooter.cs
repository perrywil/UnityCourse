using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;


	void Start () {
		projectileParent = GameObject.Find("Projectiles");

		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

	// Cant use OnBecameInvisible () because the sprite renderer is in the body not on the parent
}
