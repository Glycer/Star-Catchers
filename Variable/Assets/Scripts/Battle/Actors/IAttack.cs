using UnityEngine;
using System.Collections;

public interface IAttack {

	BattleSprite target { get; set; }

	void DealDamage(BattleSprite tar);
}
