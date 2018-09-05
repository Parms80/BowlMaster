using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text standingDisplay;

	private GameManager gameManager;
	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private float lastChangeTime;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager> (); 
	}
	
	// Update is called once per frame
	void Update () {

		standingDisplay.text = CountStanding().ToString ();

		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle ();
			standingDisplay.color = Color.red;
		}
	}

	public void Reset() {

	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.name == "Ball") {
			ballOutOfPlay = true;
		}
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
		int numStanding = CountStanding ();
		int pinFall = lastSettledCount - numStanding;
		lastSettledCount = numStanding;

		gameManager.Bowl (pinFall);

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
}
