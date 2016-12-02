using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class BattleSprite : MonoBehaviour, IAttack, IDamageable {

	public const float DAMAGE_DELAY = .05f;

	public Action<BattleSprite> Attack;

	public int health { get; set; }
	public BattleSprite target { get; set; }

	public Text txtHealth;
	public int damageStrength;

	//Use this for initialization
	public virtual void Start()
	{
		Attack += DealDamage;

		txtHealth = GetComponentInChildren<Text> ();
		health = int.Parse (txtHealth.text);
		TargetingSystem.SetTargets (this);
	}

	/// <summary>
	/// Deals damage.
	/// </summary>
	/// <param name="tar">Tar.</param>
	public void DealDamage(BattleSprite tar)
	{
		tar.TakeDamage (damageStrength);
	}

	/// <summary>
	/// Takes damage.
	/// </summary>
	/// <param name="dmg">Dmg.</param>
	public void TakeDamage(int dmg)
	{
		StartCoroutine (RunDamage(dmg));
	}

	/// <summary>
	/// Checks to see if this BattleSprite has been killed
	/// </summary>
	public virtual void KillCheck()
	{
		if (health <= 0) {
			TargetingSystem.Kill (this);
		}
	}

	/// <summary>
	/// Makes the health drop over the course of a second or two, rather than instantaneously.
	/// </summary>
	/// <returns>The damage.</returns>
	/// <param name="_dmg">Dmg.</param>
	protected IEnumerator RunDamage(int _dmg)
	{
		for (int i = 0; i < _dmg; i++) {
			health--;
			KillCheck ();

			txtHealth.text = health.ToString ();
			yield return new WaitForSeconds (DAMAGE_DELAY);
		}
	}
}
