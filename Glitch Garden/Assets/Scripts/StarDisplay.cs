using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};

	private Text starAmount;
	private int stars = 100;

	// Use this for initialization
	void Start () {
		starAmount = GetComponent<Text>();
		UpdateDisplay ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStars(int amount) {
	 //print (amount + " stars added to display");
	 stars += amount;
	 UpdateDisplay();
	}

	public Status UseStars (int amount) {
		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return Status.SUCCESS;
		}
		// no need to use else{}
		return Status.FAILURE;
	}


	private void UpdateDisplay () {
		starAmount.text = stars.ToString();
	}
}
