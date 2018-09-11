using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;
	private Animator animator;
	private PinCounter pinCounter;

//	ActionMaster actionMaster = new ActionMaster();		// We need it here as we only want one instance

	void Start () {
		animator = GetComponent<Animator> ();
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
	}
	
	void Update () {
		
	}

	// Raise standing pins during tidy
	public void RaisePins() {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding();
		}
	}

	public void LowerPins() {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower();
		}
	}

	// Clear all pins
	public void RenewPins() {
		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3 (0, 50, 0);
	}
		
	public void PerformAction (ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.Reset ||
			action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Don't know how to handle end game yet");
		}
	}
}
