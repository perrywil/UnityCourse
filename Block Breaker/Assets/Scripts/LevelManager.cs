﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name){
		Debug.Log("Level load requested for " + name);
		//Application.LoadLevel(name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest (){
		Debug.Log("Quit the game");
		Application.Quit();
	}

	public void LoadNextLevel() {
		//Application.LoadLevel(Application.loadedLevel + 1);
		// Loadlevel is outdated, its recommended to use SceneManager
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void BrickDestroyed () {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
