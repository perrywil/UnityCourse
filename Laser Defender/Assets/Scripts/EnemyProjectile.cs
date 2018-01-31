using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

	public float damage = 100f;


	public void OnBecameInvisible() {
    Destroy(gameObject);
	}

	public float GetDamage (){
		return damage;
	}

	public void HitPlayer (){
		Destroy(gameObject);
	}
}
