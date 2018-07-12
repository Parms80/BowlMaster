using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 6f;
	public float distToRaise = 40.0f;
	private Rigidbody rigidBody;

	// Helps solve wobbling pins problem where they don't settle on
	// startup. Used with changing y gravity in physics project settings
	// from -981 to -98.1
	void Awake () {
		this.GetComponent<Rigidbody>().solverVelocityIterations = 10;
	}

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
//		print (name +" "+IsStanding());
	}

	// Pin is marked as standing if its angle of tilt is within a certain range
	public bool IsStanding() {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs(270-rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		if ((tiltInX < standingThreshold ||	tiltInX > 360f - standingThreshold) &&
			(tiltInZ < standingThreshold || tiltInZ > 360f - standingThreshold)) {
			return true;
		} else {
			return false;
		}
	}

	// Raise standing pins during tidy
	public void RaiseIfStanding() {
		if (IsStanding ()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0.0f, distToRaise, 0.0f), Space.World);
		}
	}

	public void Lower() {
		transform.Translate (new Vector3 (0.0f, -distToRaise, 0.0f), Space.World);
		rigidBody.useGravity = true;
		transform.rotation = Quaternion.Euler (-90f, 0f, 0f);
	}
}
