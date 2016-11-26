using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class AnswerField : MonoBehaviour {

	public static Action Correct;
	public static Action Wrong;

	public ProblemField problem;

	private Text txt;
	private int answer;

	// Use this for initialization
	void Start () {
		Correct += ClearField;

		txt = GetComponent<Text> ();
	}

	public void CheckAnswer()
	{
		if (!int.TryParse (txt.text, out answer))
			Wrong ();
		else if (problem.CheckAnswer (answer))
			Correct ();
		else
			Wrong ();
	}

	void ClearField()
	{
		txt.text = "CORRECT";
	}
}
