using UnityEngine;
using System.Collections;

public class SpawnStars : MonoBehaviour {

	const float MIN_SPAWN_DELAY = 0.5f;
	const float MAX_SPAWN_DELAY = 2.5f;

	public GameObject[] stars;

	public Transform[] spawners;
	private bool isGameRunning = true;

	// Use this for initialization
	void Start () {
		spawners = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			spawners [i] = transform.GetChild (i);
		}

		StartCoroutine (RunTimeSpawner());
	}
	
	IEnumerator RunTimeSpawner()
	{
		int randSpawner;
		float randTime;

		while (isGameRunning) {
			randSpawner = Random.Range (0, spawners.Length);
			randTime = Random.Range (MIN_SPAWN_DELAY, MAX_SPAWN_DELAY); 

			yield return new WaitForSeconds (randTime);
			SpawnStar (spawners [randSpawner]);
		}
	}

	void SpawnStar(Transform spawner)
	{
		GameObject star = Instantiate (stars[0]);
		float rand = Random.Range (0, spawner.GetComponent<FireStar>().forceRange.x);

		star.transform.position = spawner.position;
		star.GetComponent<Rigidbody> ().AddForce (rand, spawner.GetComponent<FireStar>().forceRange.y, 0);
	}
}
