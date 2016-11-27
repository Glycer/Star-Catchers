using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AnswerField : MonoBehaviour {

	public static Action Correct;
	public static Action Wrong;

	public ProblemField problem;
	public GoodGuy pc;

	private Text txt;
	private int answer;

	// Use this for initialization
	private void Start () {
		Correct += ClearField;
		Correct += PCAtk;

		txt = GetComponent<Text> ();
	}

	/// <summary>
	/// Checks the answer.
	/// </summary>
	public void CheckAnswer()
	{
		if (!int.TryParse (txt.text, out answer))
			Wrong ();
		else if (problem.CheckAnswer (answer))
			Correct ();
		else
			Wrong ();
	}

	/// <summary>
	/// Clears the field.
	/// </summary>
	private void ClearField()
	{
		txt.text = "CORRECT";
	}

	/// <summary>
	/// Triggers the PC to attack their target.
	/// </summary>
	private void PCAtk()
	{
		pc.Attack (pc.target);
	}
}
