using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdditionProblem : IProblem {

	public const int NUM_MIN = 0;
	public const int NUM_MID = 10;
	public const int NUM_MAX = 100;

	public string equation { get; set; }
	public int solution { get; set;}

	/// <summary>
	/// Resets the solution.
	/// </summary>
	public void ResetSolution()
	{
		solution = 0;
	}

	/// <summary>
	/// Basic addition problem generator
	/// </summary>
	public string Generate()
	{
		int _num1 = Random.Range (NUM_MIN, NUM_MID);
		int _num2 = Random.Range (NUM_MIN, NUM_MID);

		solution = _num1 + _num2;
		equation = _num1 + " + " +  _num2;

		return equation;
	}

	/// <summary>
	/// Advanced addition problem generator
	/// </summary>
	/// <param name="numNums">Number of numbers to add to the equation.</param>
	public string Generate(int _numNums)
	{
		ProcessAddends (NUM_MID, _numNums);

		return equation;
	}

	/// <summary>
	/// Advanced addition problem generator
	/// </summary>
	/// <param name="numRange">Number range.</param>
	/// <param name="numNums">Number of numbers to add to the equation.</param>
	public string Generate(int _numRange, int _numNums)
	{
		_numRange = Random.Range (NUM_MID, NUM_MAX);

		ProcessAddends (_numRange, _numNums);

		return equation;
	}

	/// <summary>
	/// Processes the addends.
	/// </summary>
	/// <param name="_range">Upper limit for addend.</param>
	/// <param name="_numNums">Number of numbers to process.</param>
	private void ProcessAddends(int _range, int _numNums)
	{
		int _num1 = Random.Range (NUM_MIN, _range);
		_numNums = Random.Range (NUM_MIN + 1, NUM_MID);
		equation = _num1.ToString();

		List<int> _nums = new List<int>();

		for (int i = 0; i <= _numNums; i++) {
			_nums.Add (Random.Range (NUM_MIN, _range));
		}

		foreach (int num in _nums) {
			solution += num;
			equation += " + " + num;
		}
	}
}
