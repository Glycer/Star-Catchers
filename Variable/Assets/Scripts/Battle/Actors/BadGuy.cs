using UnityEngine;
using System.Collections;

public class BadGuy : BattleSprite {

	// Use this for initialization
	void Start () {
		//Add this to targeting system
		BattleManager.SetTargets (this);
	}
}
