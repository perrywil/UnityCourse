using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//so I can call the Image class

public class FadeInPanel : MonoBehaviour {

	public float fadeInTime = 3f;

	private Image fadePanel;
	private Color currentColor = Color.black;
	
	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();//get the image component to fade out the alpha of the panel
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.timeSinceLevelLoad < fadeInTime) {
			//Fade in
			float alphaChange = Time.deltaTime / fadeInTime; // divide the frame for the amount of time, the proportion
			currentColor.a -= alphaChange;					 // of fade that we want to use
			fadePanel.color = currentColor;												
		} else {
			gameObject.SetActive(false);
		}
	}
}
