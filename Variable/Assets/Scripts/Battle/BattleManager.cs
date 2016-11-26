using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour {

	//Action to set up targeting system
	public static Action<BattleSprite> SetTargets;

	public List<BattleSprite> good;
	public List<BattleSprite> evil;

	// Use this for initialization
	void Start () {
		AnswerField.Wrong += Backlash;
		SetTargets += SortTarget;

		Invoke ("DelayedStart", 1);
	}

	void Backlash()
	{
		foreach (GoodGuy buddy in good) {
			if (buddy.isPC) {
				buddy.TakeDamage (5);
			}
		}
	}

	void SortTarget(BattleSprite _target)
	{
		if (_target is GoodGuy)
			good.Add (_target);
		else
			evil.Add (_target);
	}

	void DelayedStart()
	{
		//Initialize targets
		foreach (GoodGuy buddy in good) {
			buddy.target = evil [0];
		}
		foreach (BadGuy buddy in evil) {
			buddy.target = good [0];
		}
	}
}
