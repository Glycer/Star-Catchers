using UnityEngine;
using System.Collections;

public class BadGuy : BattleSprite {

	public override void Start()
	{
		base.Start();

		StartCoroutine (LaDeeDa());
	}

	/// <summary>
	/// Filler coroutine
	/// </summary>
	/// <returns>The dee da.</returns>
	IEnumerator LaDeeDa()
	{
		int i = 0;

		while (i < 10) {
			health++;
			yield return new WaitForSeconds(.01f);
		}

		txtHealth.text = health.ToString();
	}
}
