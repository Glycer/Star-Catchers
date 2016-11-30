using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TargetingSystem : MonoBehaviour {

	//Actions
	public static Action<BattleSprite> SetTargets;
	public static Action<BattleSprite> Kill;

	//PC and active targeter identities
	public static GoodGuy pc;
	public static GoodGuy targeter;

	//Lists for ally and enemy targets
	public List<BattleSprite> good;
	public List<BattleSprite> evil;

	// Use this for initialization
	void Start () {
		SetTargets += SortTarget;
		Kill += RemoveFromPlay;

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
		CorrespondingList(_target).Add(_target);
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
	/// Automatically switches the target.
	/// </summary>
	/// <param name="_targeter">Targeter.</param>
	public void AutoSwitchTarget(BattleSprite _targeter)
	{
		if (_targeter.target == null) {
			_targeter.target = OpposingList (_targeter)[0];
		}
	}

	/// <summary>
	/// Removes Battlesprite from play.
	/// </summary>
	/// <param name="_target">Target.</param>
	private void RemoveFromPlay(BattleSprite _target)
	{
		_target.gameObject.SetActive (false);
		CorrespondingList (_target).Remove (_target);

		if (CorrespondingList (_target).Count == 0)
			GetComponentInParent<ToggleScreen> ().Toggle (2);
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
	/// Gives the list to the one the Battlesprite belongs to.
	/// </summary>
	/// <returns>The list the Battlesprite belongs to.</returns>
	/// <param name="_bttlSprite">Battlesprite.</param>
	private List<BattleSprite> CorrespondingList(BattleSprite _bttlSprite)
	{
		return (_bttlSprite is GoodGuy) ? good : evil;
	}

	/// <summary>
	/// Gives the opposite list to the one the Battlesprite belongs to.
	/// </summary>
	/// <returns>The opposite list to the one the Battlesprite belongs to.</returns>
	/// <param name="_bttleSprite">Battlesprite.</param>
	private List<BattleSprite> OpposingList(BattleSprite _bttlSprite)
	{
		return (_bttlSprite is GoodGuy) ? evil : good;
	}
}
