using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public static int breakableCount;
	//private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;


	void Awake (){
		breakableCount = 0;
	}
	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		//keep track of breackable bricks
		if (isBreakable) {
			breakableCount++;
			//print(breakableCount);
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}


	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		
		if (isBreakable) {
			HandleHits();
		}

	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			//print(breakableCount);
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	// TODO Remove this method once we actually win!
	//void SimulateWin () {
	//	levelManager.LoadNextLevel();
	//}
}
