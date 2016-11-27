using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class BattleSprite : MonoBehaviour, IAttack, IDamageable {

	public const float DAMAGE_DELAY = .1f;

	public Action<BattleSprite> Attack;

	public int health { get; set; }
	public BattleSprite target { get; set; }

	public Text txtHealth;
	public int damageStrength;

	public virtual void Start()
	{
		Attack += DealDamage;

		txtHealth = GetComponentInChildren<Text> ();
		health = int.Parse (txtHealth.text);
		BattleManager.SetTargets (this);
	}

	public void DealDamage(BattleSprite tar)
	{
		tar.TakeDamage (damageStrength);
	}

	public void TakeDamage(int dmg)
	{
		StartCoroutine (RunDamage(dmg));
	}

	protected IEnumerator RunDamage(int _dmg)
	{
		for (int i = 0; i < _dmg; i++) {
			health--;
			txtHealth.text = health.ToString ();
			yield return new WaitForSeconds (DAMAGE_DELAY);
		}
	}
}
