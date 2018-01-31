using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float damage = 100;


	public void OnBecameInvisible() {
    Destroy(gameObject);
	}

	public float GetDamage (){
		return damage;
	}

	public void Hit (){
		Destroy(gameObject);
	}
		
}
