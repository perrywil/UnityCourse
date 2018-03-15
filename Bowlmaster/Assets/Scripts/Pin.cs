using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //print(name + IsStanding());
    }

    public bool IsStanding() {
        // checks the angle value, and if it is 180 degrees or greater, I subtract it from 360

        float tiltX = (transform.eulerAngles.x < 180f) ? transform.eulerAngles.x : 360 - transform.eulerAngles.x;
        float tiltZ = (transform.eulerAngles.z < 180f) ? transform.eulerAngles.z : 360 - transform.eulerAngles.z;

        if (tiltX > standingThreshold || tiltZ > standingThreshold) {
            return false;
        } else {
            return true;
        }
    }



    // old code for IsStanding but since pins shake it does not return true:
    //Vector3 rotationInEuler = transform.rotation.eulerAngles;

    // Mathf.Abs returns an absolute value -3 = 3 so it doesnt matter where the pin tilts
    //float tiltInX = Mathf.Abs(rotationInEuler.x);
    //float tiltInZ = Mathf.Abs(rotationInEuler.z);

    //if (tiltInX < standingTreshold && tiltInZ < standingTreshold) {
    //    return true;
    //} else {
    //    return false;
    //        }
}
