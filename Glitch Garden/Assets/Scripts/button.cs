using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown () {
		//Debug.Log (name + " is pressed");
	
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	void OnMouseUp () {
		GetComponent<SpriteRenderer>().color = Color.black;
		selectedDefender = defenderPrefab;
		print (selectedDefender);
	}
}
