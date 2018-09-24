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
			float halfFloorWidth = floor.transform.localScale.x / 2;
			float xPos = Mathf.Clamp(ball.transform.position.x + xNudge, -halfFloorWidth, halfFloorWidth);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			ball.transform.position = new Vector3 (xPos, yPos, zPos);
		}
	}

	public void DragStart () {
		if (!ball.inPlay) {
			dragStartPosition = Input.mousePosition;
			dragStartTime = Time.time;
		}
	}

	// Speed and direction of ball depends on speed and direction of drag
	public void DragEnd () {
		if (!ball.inPlay) {
			Vector3 dragEndPosition = Input.mousePosition;
			float dragEndTime = Time.time;
			float dragDuration = dragEndTime - dragStartTime;
			float ballVelocityX = (dragEndPosition.x - dragStartPosition.x) / dragDuration;
			float ballVelocityZ = (dragEndPosition.y - dragStartPosition.y) / dragDuration;
			Vector3 launchVelocity = new Vector3 (ballVelocityX, 0, ballVelocityZ);
			ball.LaunchBall (launchVelocity);
		}
	}

}
