using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject enemyProjectile;
	public float health = 150f;
	public float EnemyBeamSpeed = 10f;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 20;
	public AudioClip explosionSound;

	private ScoreCount scoreCount;

	void Start (){
		scoreCount = GameObject.Find("Score").GetComponent<ScoreCount>();
	}
	void OnTriggerEnter2D (Collider2D collider) {
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			health -= missile.GetDamage ();
			missile.Hit();
			if (health <= 0) {
				Destroy(gameObject);
				scoreCount.ScorePoints(scoreValue);
				AudioSource.PlayClipAtPoint(explosionSound, transform.position);
			}
		}
	}

	void EnemyFire () {
		Vector3 offset = new Vector3(0, -1, 0);
		GameObject enemyBeam = Instantiate(enemyProjectile, transform.position + offset, Quaternion.identity) as GameObject;
		enemyBeam.GetComponent<Rigidbody2D>().velocity = Vector3.down * EnemyBeamSpeed;
	}

	void Update () {
		float probability = Time.deltaTime * shotsPerSeconds;
		if(Random.value < probability){
			EnemyFire ();
		}
	}
}
