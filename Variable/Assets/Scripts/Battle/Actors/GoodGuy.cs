﻿using UnityEngine;
using System.Collections;

public class GoodGuy : BattleSprite {

	public bool isPC;

	// Use this for initialization
	void Start () {
		//Add this to targeting system
		BattleManager.SetTargets (this);
	}
}
