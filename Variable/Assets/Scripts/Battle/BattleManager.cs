using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BattleManager : MonoBehaviour {

	public const int BASE_DAMAGE = 5;

	// Use this for initialization
	private void Start () {
		AnswerField.Wrong += Backlash;
	}

	/// <summary>
	/// Damage Player Character. This goes to the Wrong delegate in AnswerField, to damage the PC
	/// when they enter an incorrect solution
	/// </summary>
	private void Backlash()
	{
		TargetingSystem.pc.TakeDamage (BASE_DAMAGE);
	}
}