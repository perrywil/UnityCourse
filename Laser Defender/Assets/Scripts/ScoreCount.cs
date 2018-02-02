using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // added to get GetComponent<Text>();

public class ScoreCount : MonoBehaviour {
	public int score = 0;
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
	public void Reset () {
		score = 0;
		myText.text = score.ToString();
	}
}
