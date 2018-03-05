using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;

	
	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown ()
	{
		//Debug.Log (name + " is pressed");

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		print (selectedDefender);
	}

	//void OnMouseUp () {
	//	GetComponent<SpriteRenderer>().color = Color.black;
	//	selectedDefender = defenderPrefab;
	//	print (selectedDefender);
	//}
}
