using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject defenderParent;
	private StarDisplay starDisplay;

	void Start () {
		defenderParent = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();

		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}

	void OnMouseDown () {
		//Calculate the world position of the mouse click
		Vector2 rawPos = CalculateWorldPointOfMouseClick ();
		//Round the value of the position
		Vector2 roundedPos = SnapToGrid (rawPos);
		//Keeps track of which defender is selected in the button menu
		GameObject defender = Button.selectedDefender;
		// Get the cost of each defender from the starCost component in Defender
		int defenderCost = defender.GetComponent<Defender>().starCost;
		// if the cost of the defender "equals" Success
		if (starDisplay.UseStars (defenderCost) == StarDisplay.Status.SUCCESS) {
			//Spawns the defender in the gamefloor
			SpawnDefender (roundedPos, defender);
		} else {
			Debug.Log("Insuficient Stars");
		}
	}

	// refacored method that is used in OnMouseDown () as SpawnDefender (roundedPos, defender);
		void SpawnDefender(Vector2 roundedPos, GameObject defender) {
			Quaternion zeroRot = Quaternion.identity;
			GameObject newDef = Instantiate (defender, roundedPos, zeroRot) as GameObject;

			newDef.transform.parent = defenderParent.transform;
		}



	void enoughStars() {
		
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2 (newX, newY);
	}


	Vector2 CalculateWorldPointOfMouseClick () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 wierdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (wierdTriplet);

		return worldPos;
	}

}

