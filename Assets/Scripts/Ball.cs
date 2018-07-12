using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector3 launchVelocity;
	public bool inPlay = false;
	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 ballStartPosition;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
		rigidBody.useGravity = false;
		ballStartPosition = transform.position;
	}

	public void LaunchBall(Vector3 velocity) {
		inPlay = true;
		rigidBody.velocity = velocity;
		rigidBody.useGravity = true;
		audioSource.Play ();
	}

	public void Reset() {
		inPlay = false;
		transform.position = ballStartPosition;
		transform.rotation = Quaternion.identity;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}
}
