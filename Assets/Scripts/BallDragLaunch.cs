using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball;
	private GameObject floor;
	private Vector3 dragStartPosition;
	private float dragStartTime;

	void Start () {
		ball = GetComponent<Ball> ();
		floor = GameObject.Find("Floor");
	}

	// Adjusts start position of ball
	public void MoveStart (float xNudge) {
		if (!ball.inPlay) {
			if (ball.transform.position.x < floor.transform.localScale.x / 2 - 10 &&
				ball.transform.position.x > -floor.transform.localScale.x / 2 + 10) {
				ball.transform.Translate (new Vector3 (xNudge, 0, 0));
			}
		}
	}

	public void DragStart () {
		dragStartPosition = Input.mousePosition;
		dragStartTime = Time.time;
	}

	// Speed and direction of ball depends on speed and direction of drag
	public void DragEnd () {
		Vector3 dragEndPosition = Input.mousePosition;
		float dragEndTime = Time.time;
		float dragDuration = dragEndTime - dragStartTime;
		float ballVelocityX = (dragEndPosition.x - dragStartPosition.x) / dragDuration;
		float ballVelocityZ = (dragEndPosition.y - dragStartPosition.y) / dragDuration;
		Vector3 launchVelocity = new Vector3 (ballVelocityX, 0, ballVelocityZ);
		ball.LaunchBall (launchVelocity);
	}

}
