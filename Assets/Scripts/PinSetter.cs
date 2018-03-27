using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	private bool ballEnteredBox = false;

	void Start () {
	}
	
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();
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
