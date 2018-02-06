﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	// Use this for initialization
	void Awake (){
		DontDestroyOnLoad (gameObject);
	}

	void Start (){
		audioSource = GetComponent<AudioSource>();
		
	}

	void OnLevelWasLoaded (int level)
	{
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		if (thisLevelMusic) { // if there's some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
