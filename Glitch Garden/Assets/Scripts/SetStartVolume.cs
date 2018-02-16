using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		//find music manager
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
			Debug.Log ("Found music manager " + musicManager);
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.ChangeVolume(volume);
		} else {
			Debug.LogWarning ("no music manager found in Start scene, can't set volume");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
