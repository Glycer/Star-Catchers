using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour {

	public const int BASE_DAMAGE = 5;

	//Actions to set up targeting system and change target
	public static Action<BattleSprite> SetTargets;

	//Lists for ally and enemy targets
	public List<BattleSprite> good;
	public List<BattleSprite> evil;

	//PC and active targeter identities
	private GoodGuy pc;
	public static GoodGuy targeter;
	public static bool isAnswering = false;

	// Use this for initialization
	private void Start () {
		AnswerField.Wrong += Backlash;
		SetTargets += SortTarget;

		Invoke ("DelayedStart", 1);
	}

	private void DelayedStart()
	{
		//Identify Player Character and move them to the top of the good List
		foreach (GoodGuy buddy in good) {
			if (buddy.isPC) {
				pc = buddy;
				good [0] = pc;
			}
		}

		//Initialize targets and targeter
		foreach (GoodGuy buddy in good) {
			buddy.target = evil [0];
		}
		foreach (BadGuy buddy in evil) {
			buddy.target = good [0];
		}

		targeter = pc;
	}

	/// <summary>
	/// Sorts target. This goes to the SetTargets delegate, to be used by GoodGuy and BadGuy
	/// </summary>
	/// <param name="_target">Target.</param>
	private void SortTarget(BattleSprite _target)
	{
		if (_target is GoodGuy)
			good.Add (_target);
		else
			evil.Add (_target);
	}

	/// <summary>
	/// Sets as target.
	/// </summary>
	/// <param name="_newTarget">New target.</param>
	public void SetAsTarget(BattleSprite _newTarget)
	{
		targeter.target = _newTarget;
		Debug.Log (_newTarget);
	}

	/// <summary>
	/// Sets targeter.
	/// </summary>
	/// <param name="_targeter">Targeter.</param>
	public void SetAsTargeter(GoodGuy _targeter)
	{
		targeter = _targeter;
	}

	/// <summary>
	/// Damage Player Character. This goes to the Wrong delegate in AnswerField, to damage the PC
	/// when they enter an incorrect solution
	/// </summary>
	private void Backlash()
	{
		pc.TakeDamage (BASE_DAMAGE);
	}
}