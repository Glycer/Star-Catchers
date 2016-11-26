using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BattleSprite : MonoBehaviour, IAttack, IDamageable {
	
	public Action<BattleSprite> Attack;
	//public Action<BattleSprite> SetTargets;

	public int health { get; set; }
	public BattleSprite target { get; set; }

	public List<BattleSprite> lstTargets;

	protected int damageStrength;

	void Start()
	{
		Attack += DealDamage;
	}

	public void DealDamage(BattleSprite tar)
	{
		tar.TakeDamage (damageStrength);
	}

	public void TakeDamage(int dmg)
	{
		health -= dmg;
	}
}
