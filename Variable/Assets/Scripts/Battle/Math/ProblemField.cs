using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProblemField : MonoBehaviour {

	//public enum ProblemTypes { Addition, Subtraction, Multiplication, Division };
	//public ProblemTypes problemType;

	private List<IProblem> problemTypes;
	private int probTypeIndex = 0;

	AdditionProblem addProb;
	/* SubtractionProblem subProb;
	 * MultiplicationProblem multiProb;
	 * DivisionProblem divProb;
	 */

	private Text txt;

	// Use this for initialization
	void Start () {
		AnswerField.Correct += Generate;

		txt = GetComponent<Text> ();
		addProb = new AdditionProblem ();
		//Create instances of other problem types

		problemTypes = new List<IProblem> {addProb};

		Generate ();
	}

	void Generate()
	{
		txt.text = problemTypes [probTypeIndex].Generate ();
	}

	public bool CheckAnswer(int answer)
	{
		if (answer == problemTypes [probTypeIndex].solution)
			return true;
		else
			return false;
	}
}
