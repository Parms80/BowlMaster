using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1() {
		int[] rolls = { 1 };
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T02Bowl12() {
		int[] rolls = { 1,2 };
		string rollsString = "12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T03Bowl123() {
		int[] rolls = { 1,2, 3 };
		string rollsString = "123";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T04Bowl1234() {
		int[] rolls = { 1,2, 3,4 };
		string rollsString = "1234";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T05BowlStrike() {
		int[] rolls = { 10 };
		string rollsString = "X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T06BowlTwoStrikes() {
		int[] rolls = { 10, 10 };
		string rollsString = "X X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T07BowlX1() {
		int[] rolls = { 10, 1 };
		string rollsString = "X 1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T08BowlSpare() {
		int[] rolls = { 1, 9 };
		string rollsString = "1/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T09BowlTwoSpares() {
		int[] rolls = { 1,9, 9,1 };
		string rollsString = "1/9/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T10BowlTwoSparesAndStrike() {
		int[] rolls = { 1,9, 9,1, 10, 1,2 };
		string rollsString = "1/9/X 12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T11BowlAllOnes() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 };
		string rollsString = "11111111111111111111";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T12BowlAllStrikes() {
		int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10,10,10 };
		string rollsString = "X X X X X X X X X X X X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T13BowlSpareInLastFrame() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,7 };
		string rollsString = "1111111111111111111/7";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T14BowlStrikeInLastFrame() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,7 };
		string rollsString = "111111111111111111X17";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T15BowlStrikeAndSpareInLastFrame() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,5,5 };
		string rollsString = "111111111111111111X55";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T16Bowl128() {
		int[] rolls = { 1,2, 8 };
		string rollsString = "128";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T17Bowl0() {
		int[] rolls = { 0 };
		string rollsString = "-";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}
}