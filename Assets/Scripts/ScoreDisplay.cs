using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	// Use this for initialization
	void Start () {
		rollTexts [0].text = "X";
		frameTexts [0].text = "0";
	}

	public void FillRoles (List<int> rolls) {
		string scoresString = FormatRolls (rolls);
		for (int i = 0; i < scoresString.Length; i++) {
			rollTexts [i].text = scoresString [i].ToString ();
		}
	}

	public void FillFrames (List<int> frames) {
		for (int i = 0; i < frames.Count; i++) {
			frameTexts [i].text = frames [i].ToString ();
		}
	}

	public static string FormatRolls (List<int> rolls) {
		string output = "";

		int currentRoll = 0;
		foreach (int roll in rolls) {
			if (roll == 0) {
				output += "-";
			} else if (currentRoll >= 17 && roll == 10) {				// Strike in frame 10
				output += "X";
			} else if (currentRoll%2 == 1 && roll + rolls[currentRoll-1] == 10) {	// Spare
				output += "/";
			} else if (roll == 10) {									// Strike
				output += "X ";
			} else {													// Normal 1-9 bowl
				output += roll.ToString ();
			}
			currentRoll++;
		}

//		for (int i = 0; i < rolls.Count; i++) {
//			int box = output.Length + 1;
//
//			if (rolls [i] == 0) {
//				output += "-";
//			} else if ((box % 2 == 0 || box == 21) && rolls [i - 1] + rolls [i] == 10) { // SPARE
//				output += "/";
//			} else if (box >= 19 && rolls [i] == 10) {						// STRIKE in frame 10
//				output += "X";
//			} else if (rolls [i] == 10) {								  	// STRIKE in frame 1-9
//				output += "X ";
//			} else {
//				output += rolls [i].ToString ();							// Normal 1-9 bowl
//			}
//		}

		return output;
	}
}
