using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> bowls = new List<int>();

    private PinSetter pinSettter;
    private Ball ball;
	// Use this for initialization
	void Start () {
		pinSettter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    public void Bowl(int pinFall)
    {
        bowls.Add(pinFall);

        ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
        pinSettter.PerformAction(nextAction);
        ball.Reset();
    }
}
