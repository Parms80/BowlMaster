using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

	// Returns a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative (List<int> rolls) {

		List<int> cumulativeScores = new List<int>();
		int runningTotal = 0;
		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}

	// Return a list of individual frame scores, NOT cumulative
	public static List<int> ScoreFramesOld (List<int> rolls) {
		List<int> frameList = new List<int> ();

		// Your code here
		int frameScores = 0;
		int currentRoll = 0;
		bool spare = false;
		bool strikeLastFrame = false;
		foreach (int roll in rolls) {
			if (roll == 10) {			// Strike
				currentRoll+=2;
				strikeLastFrame = true;
				frameScores += 10;
			} else {
				frameScores += roll;
				if (frameScores == 10 && !strikeLastFrame) {		// Spare
					currentRoll++;
					spare = true;
				} else {					 
					if (currentRoll % 2 == 0) {		// 1st roll of frame
						if (spare) {
							frameList.Add (frameScores);
							frameScores = roll;
							spare = false;
						} 
//						else if (strikeLastFrame) {
//							frameList.Add (frameScores);
////							frameScores -= 10;
//						}
					} else {						// 2nd roll of frame
						if (strikeLastFrame) {
							frameList.Add (frameScores);
							frameList.Add (frameScores - 10);
							strikeLastFrame = false;
							frameScores = 0;
						} else if (!spare) {
							frameList.Add (frameScores);
							frameScores = 0;
						}
					}
					currentRoll++;
				}
			}
		}
		return frameList;
	}

	// Return a list of individual frame scores
	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frames = new List<int> ();

		// Index i points to 2nd bowl of frame
		for (int i = 1; i < rolls.Count; i += 2) {
			if (frames.Count == 10) {				// Prevents 11th frame score
				break;
			}

			if (rolls [i-1] + rolls [i] < 10) {		// Normal "open" frame
				frames.Add (rolls [i-1] + rolls [i]);
			}

			if (rolls.Count - i <= 1) {				// Insure at least 1 look-ahead available
				break;
			}

			if (rolls [i-1] == 10) {					// Strike
				i--;									// Strike frame has just one bowl
				frames.Add (10 + rolls [i+1] + rolls [i+2]);
			} else if (rolls[i-1] + rolls[i] == 10) {	// Calculate Spare bonus
				frames.Add(10 + rolls[i+1]);
			}
		}

		return frames;
	}
}
