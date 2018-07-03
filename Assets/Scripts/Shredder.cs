using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	// Destroy any pins that have left the collider box attached to the pin setter
	void OnTriggerExit (Collider collider) {
		GameObject thingLeft = collider.gameObject;
		if (thingLeft.GetComponent<Pin> ()) {
			Destroy (thingLeft);
		}
	}
}
