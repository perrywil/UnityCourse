using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}

    public void MoveStart (float amount) {
        if (! ball.inPlay) {
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
	
	public void DragStart() {
        // Capture time & position of drag start
        if(!ball.inPlay){
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd() {
        // Launch the ball
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;
            // variables state that when mouse moves up(y) ball moves deep(z), ball and mouse will move sidways equally(x)
            float launchSpeedx = (dragEnd.x - dragStart.x) / dragDuration;
            float launshSpeedz = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 launchVelocity = new Vector3(launchSpeedx, 0, launshSpeedz);
            ball.Launch(launchVelocity);
        }
    }
}
