using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	public GameObject pinSet;
	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private float lastChangeTime;
	private int lastSettledCount = 10;
	private Ball ball;
	private Animator animator;

	ActionMaster actionMaster = new ActionMaster();		// We need it here as we only want one instance

	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
		animator = GetComponent<Animator> ();
	}
	
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle ();
			standingDisplay.color = Color.red;
		}
	}

	public void SetBallOutOfPlay() {
		ballOutOfPlay = true;
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
//		Instantiate (pinSet, new Vector3 (0, 0, 1829), Quaternion.identity);
	}

	void UpdateStandingCountAndSettle () {
		int numStandingThisFrame = CountStanding ();
		if (numStandingThisFrame != lastStandingCount) {
			lastStandingCount = numStandingThisFrame;
			lastChangeTime = Time.time;
			return;
		}

		float settleTime = 3.0f;
		if (Time.time - lastChangeTime > settleTime) {
			PinsHaveSettled ();
		}
	}

	void PinsHaveSettled() {
		TriggerPinsetterAnimationBasedOnPinsKnockedDown ();
		ball.Reset ();
		lastStandingCount = -1;
		standingDisplay.color = Color.green;
		ballOutOfPlay = false;
	}

	int CountStanding() {
		int numStanding = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding ()) {
				numStanding++;
			}
		}
		return numStanding;
	}

	void TriggerPinsetterAnimationBasedOnPinsKnockedDown() {
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		ActionMaster.Action action = actionMaster.Bowl (pinFall);
		Debug.Log (action);

		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.Reset ||
			action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			lastSettledCount = 10;
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Don't know how to handle end game yet");
		}
	}
}
