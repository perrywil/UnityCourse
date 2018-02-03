using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public GameObject projectile;
	public float speed = 15.0f;
	public float padding = 0.7f;
	public float beamSpeed = 5f;
	public float firingRate = 0.2f;
	public float health = 150f;

	float xmin = -5;
	float xmax = 5;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 righttmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftmost.x + padding;
		xmax = righttmost.x - padding;
	}
	void Fire () {
		Vector3 offset = new Vector3(0, 1, 0);
		GameObject beam = Instantiate(projectile, transform.position + offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = Vector3.up * beamSpeed;

	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.0000001f, firingRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("Fire");
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

	// restrict the player to the game-space
	float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
	transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	void Die (){
		Destroy(gameObject);
		LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Win Screen");
	}

	void OnTriggerEnter2D (Collider2D collider) {
		EnemyProjectile missile = collider.gameObject.GetComponent<EnemyProjectile> ();
		if (missile) {
			health -= missile.GetDamage ();
			missile.HitPlayer();
			if (health <= 0) {
				Die();
			}
		}
	}
}