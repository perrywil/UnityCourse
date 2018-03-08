using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;

	//public float secondsLeft; // TODO make secondsLeft private once its working
	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winText;

	// Use this for initialization
	void Start ()
	{
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		FindYouWin ();
		winText.SetActive(false);
		//secondsLeft = levelSeconds;
	}

	void FindYouWin () {
		winText = GameObject.Find ("You Win");
		if (!winText) {
			Debug.LogWarning ("create You Win");
		}
	}
	
	// Update is called once per frame
	void Update () {
		// calculates the advancement of the slider when secondsLeft are reduced.
		// no need to use secondsLeft any more since Time.timeSinceLevelLoad calculates 
		//automatically the time left since the level starts
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		// isEndOfLevel is used so we just get a single call
		if (timeIsUp && !isEndOfLevel){
			HandleWinCondition ();
		}
	}

	void HandleWinCondition () {
		DestroyAllTaggedObjects();
		audioSource.Play ();
		winText.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	// Destroys all objects with the tag destroyOnWin
	void DestroyAllTaggedObjects () {
	     GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag ("destroyOnWin");

		foreach(GameObject taggedObject in taggedObjectArray){
			Destroy(taggedObject);
	     }
			
	}

	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}

}
