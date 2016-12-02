using UnityEngine;
using System.Collections;

public class FutureSelf : BattleSprite {

	public int damageThreshold;

	/// <summary>
	/// Checks to see if this BattleSprite has been reduced below tolerable hit points
	/// </summary>
	public override void KillCheck ()
	{
		if (health < damageThreshold) {
			GetComponent<Animator> ().Play ("PortOut");
		}
	}
}
