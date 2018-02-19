using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start ()
	{
		if (autoLoadNextLevelAfter <= 0) {
			Debug.Log ("Auto load level disabled, use a positive number in seconds");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

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
}
