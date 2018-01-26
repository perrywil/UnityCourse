﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {

	public int maxHits;
	public Sprite[] hitSprites;
	private int timesHit;
	private LevelManager levelManager;


	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}


	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		timesHit++;

		if (timesHit >= maxHits) {
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites () {
		int spriteIndex = timesHit -1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}

	// TODO Remove this method once we actually win!
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
