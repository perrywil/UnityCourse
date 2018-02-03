using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // added to get GetComponent<Text>();

public class ScoreCount : MonoBehaviour {
	//changed to static so it keeps the score in the ScoreCount even when there is no ScoreCount object,
	// it stores it in a template instead of a instance.
	//
	public static int score = 0;
	private Text myText;

	// Use this for initialization
	void Start (){
		myText = GetComponent<Text>();
		Reset();
	}


	 public void ScorePoints(int points) {
		score += points;
		myText.text = score.ToString();
	}
	
	// Update is called once per frame
	public static void Reset () {
		score = 0;
	}
}
