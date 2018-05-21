﻿using System.Collections;
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

        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;                                            // Score box 1 to 21

            if (rolls[i] == 0)                                                      // Always enter 0 as -
            {
                output += "-";
            } else if (box % 2 == 0 && rolls[i - 1] + rolls[i] == 10)               // SPARE anywhere

                {
                    output += "/";
                } else if (box >= 19 && rolls[i] == 10)                             // STRIKE in frame 10
                {
                    output += "X";
                } else if (rolls[i] == 10)                                          // STRIKE in frame 1-9
                    {
                        output += "X ";
                    } else
                        {
                            output += rolls[i].ToString();                          // Normal 1-9 bowl   
                        } 
        }

        return output;
    }
}
