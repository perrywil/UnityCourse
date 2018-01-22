﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Paddle paddle;

	private bool hasStarted = false;

	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			// lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// wait for a mouse press to launch.
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log ("mouse clicked");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}
}
