using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starAmount;
	private int stars = 0;


	// Use this for initialization
	void Start () {
		starAmount = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStars(int amount) {
	 //print (amount + " stars added to display");
	 stars += amount;
	 UpdateDisplay();
	}

	void UseStars (int amount) {
		stars -= amount;
		UpdateDisplay();
	}


	private void UpdateDisplay () {
		starAmount.text = stars.ToString();
	}
}
