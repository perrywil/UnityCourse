﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PinSetter : MonoBehaviour {
    public Text standingDisplay;
    public GameObject pinSet;
    public bool ballOutOfPlay = false;
    private int lastSettledCount = 10; // TODO make private

    private Ball ball;
    private float lastChangeTime;
    private int lastStandingCount = -1;
    private Animator animator;
    private ActionMaster actionMaster = new ActionMaster(); // We need action master here as we only want 1 instance

    // Use this for initialization
    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    public void RaisePins()
    {
        Debug.Log("Raising pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renewing pins");
        Instantiate(pinSet, new Vector3(0, 30, 1829), Quaternion.identity);// Quaternion.identity is for no rotation
    }

    void UpdateStandingCountAndSettle()
    {
        // Update the lastStandingCount
        // Call PinsHaveSettled() when they have
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;  // How long to wait to consider pins settled
        if ((Time.time - lastChangeTime) > settleTime)
        { // If last change > 3s ago
            PinsHaveSettled();
        }
    }


    void PinsHaveSettled() {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing; // the settled count is the remaining pins in the lane.

        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        Debug.Log("Pinfall: " + pinFall + " " + action);

        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        } else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("Don't know how to handle end game yet");
        }

        ball.Reset();
        lastStandingCount = -1; // Indicates pins have settled, and ball not back in box
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }

    int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }

        return standing;
    }
}