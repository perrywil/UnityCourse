using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] attckerPrefabArray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attckerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	void Spawn (GameObject myGameObject) {
		GameObject myAttacker = Instantiate(myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}



	bool isTimeToSpawn (GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();

		//Spawn this line as often as often is marked in attacker seenEvery Seconds
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		}
		// if the value is above 1 we spawn an attacker if not we don't spawn
		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		// can be made more compact like this: 
		// return (Random.value < threshold);

		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}
	}

}
