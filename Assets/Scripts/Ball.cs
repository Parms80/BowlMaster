using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool inPlay = false;
	private Rigidbody rigidBody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
		rigidBody.useGravity = false;
//		LaunchBall (launchVelocity);
	}

	public void LaunchBall(Vector3 velocity) {
		inPlay = true;
		rigidBody.velocity = velocity;
		rigidBody.useGravity = true;
		audioSource.Play ();
	}
}
