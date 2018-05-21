using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollTexts, frameTexts;

	// Use this for initialization
	void Start () {
        //rollTexts[0].text = "X";
        //frameTexts[0].text = "0";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FillRolls(List<int> rolls)
    {
        string ScoresString = FormatRolls(rolls);

        for (int i = 0; i < ScoresString.Length; i++)
        {
            rollTexts[i].text = ScoresString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i=0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls (List<int> rolls)
    {
        string output = "";

        return output;
    }
}
