using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PinSetter : MonoBehaviour {

    public GameObject pinSet;
 
    private Animator animator;
    private ActionMasterOld actionMaster = new ActionMasterOld(); // We need action master here as we only want 1 instance
    private PinCounter pinCounter;

    // Use this for initialization
    void Start() {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
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


    public void PerformAction(ActionMasterOld.Action action)
    {
        if (action == ActionMasterOld.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMasterOld.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
            
        }
        else if (action == ActionMasterOld.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMasterOld.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet");
        }
    }
}