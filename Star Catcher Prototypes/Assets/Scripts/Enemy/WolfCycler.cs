using UnityEngine;
using System.Collections;

public class WolfCycler : MonoBehaviour {

	public WolfAI wolf;

	const int SPAWN_CHANCE = 2;
	const int SPAWN_DELAY = 20;
	const int LIFESPAN = 4;

	// Use this for initialization
	void Start () {
		wolf.gameObject.SetActive (false);

		StartCoroutine (SpawnCycle());
	}

	IEnumerator SpawnCycle()
	{
		for (int i = 0; i < StaticVariables.levelDuration; i += SPAWN_DELAY)
		{
			int _rand = Random.Range (0, SPAWN_CHANCE);

			//Don't let wolf spawn immediately
			if (i < SPAWN_DELAY) {
				_rand = 0;
			}

			if (_rand == 1) {
				Spawn ();
			}
			yield return new WaitForSeconds (SPAWN_DELAY);
		}
	}

	void Spawn()
	{
		wolf.transform.position = transform.position;
		wolf.gameObject.SetActive (true);
		wolf.Run ();

		StartCoroutine (DeactivateEnemy());
	}

	IEnumerator DeactivateEnemy()
	{
		yield return new WaitForSeconds (LIFESPAN);
		wolf.gameObject.SetActive (false);
	}
}
