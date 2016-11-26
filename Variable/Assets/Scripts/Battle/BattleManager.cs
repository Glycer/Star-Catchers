using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour {
	
	public static Action<BattleSprite> SetTargets;

	public List<GoodGuy> good;
	public List<BadGuy> evil;

	// Use this for initialization
	void Start () {
		AnswerField.Wrong += Backlash;
	}

	void Backlash()
	{
		foreach (GoodGuy buddy in good) {
			if (buddy.isPC) {
				buddy.TakeDamage (5);
			}
		}
	}
}
