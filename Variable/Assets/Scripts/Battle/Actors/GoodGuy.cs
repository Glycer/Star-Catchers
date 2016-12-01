using UnityEngine;
using System.Collections;

public class GoodGuy : BattleSprite {

	public bool isPC;
	private bool isRunning = true;

	public override void Start()
	{
		base.Start();

		StartCoroutine (Squeak());
	}

	/// <summary>
	/// Squeak this instance. <- Glorious auto-filled summary. This is a filler coroutine.
	/// </summary>
	IEnumerator Squeak()
	{
		while (isRunning) {
			txtHealth.text = "Squeak";
			yield return new WaitForSeconds (1);
			txtHealth.text = health.ToString();
			yield return new WaitForSeconds (5);
		}
	}
}