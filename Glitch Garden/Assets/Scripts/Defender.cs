using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStars (int amount) {
		starDisplay.AddStars(amount);

	}


	void OnTriggerEnter2D (){
		//Debug.Log (name + "has triggered");
	}
}
