using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	public int lastStandingCount = -1;
	private bool ballEnteredBox = false;
	private float lastChangeTime;
	private Ball ball;

	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
			CheckStandingCount ();
		}
	}

	void CheckStandingCount() {
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
		ball.Reset ();
		lastStandingCount = -1;
		standingDisplay.color = Color.green;
		ballEnteredBox = false;
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

	void OnTriggerEnter(Collider collider) {
		GameObject thingHit = collider.gameObject;
		if (thingHit.GetComponent<Ball>()) {
			standingDisplay.color = Color.red;
			ballEnteredBox = true;
		}
	}

	void OnTriggerExit (Collider collider) {
		GameObject thingLeft = collider.gameObject;
		if (thingLeft.GetComponent<Pin> ()) {
			Destroy (thingLeft);
		}
	}
}
