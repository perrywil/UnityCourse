using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        // we have to calculate the distance of the camera from the ball
        offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // the transform of the camera changes as the transform of the ball
        // making the camera move towards the pins with the ball
        if (transform.position.z <= 1829f) { // in fron of head pin
            transform.position = ball.transform.position + offset;
        }
        
	}
}
