using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> rolls = new List<int>();

    private PinSetter pinSettter;
    private Ball ball;
    private ScoreDisplay scoreDiscplay;

	// Use this for initialization
	void Start () {
		pinSettter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDiscplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall)
    {
        try
        { 
        rolls.Add(pinFall);
        ball.Reset();

        pinSettter.PerformAction(ActionMaster.NextAction(rolls));
        } catch
          {
            Debug.LogWarning("Something whent wrong in Bowl()");
          }
        try
        {
            scoreDiscplay.FillRolls(rolls);
            scoreDiscplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        } catch
          {
            Debug.LogWarning("Error in Bowl() with: scoreDiscplay.FillRollCard(bowls);");
          }

        
    }
}
