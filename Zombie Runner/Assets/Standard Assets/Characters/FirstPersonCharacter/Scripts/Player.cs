using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject[] spawnPoints;
    public bool reSpawn = false;

    private GameObject currentPoint;
    int index;
    private bool lastToggle;

	// Use this for initialization
	void Start () {
        ReSpawn();
    }
	
	// Update is called once per frame
	void Update () {
		if (lastToggle != reSpawn)
        {
            ReSpawn();
            reSpawn = false;
        } else
        {
            lastToggle = reSpawn;
        }
	}

    private void ReSpawn()
    {
        index = Random.Range(0, spawnPoints.Length);
        currentPoint = spawnPoints[index];
        this.transform.position = currentPoint.transform.position;
    }
}
