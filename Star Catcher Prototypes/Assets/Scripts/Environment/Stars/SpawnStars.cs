using UnityEngine;
using System.Collections;

public class SpawnStars : MonoBehaviour {

	const int MAX_SPAWN_DELAY = 3;

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
			randTime = Random.Range (.5f, MAX_SPAWN_DELAY); 

			yield return new WaitForSeconds (randTime);
			SpawnStar (spawners [randSpawner]);
		}
	}

	void SpawnStar(Transform spawner)
	{
		GameObject star = Instantiate (stars[0]);

		star.transform.position = spawner.position;
		star.GetComponent<Rigidbody> ().AddForce (spawner.GetComponent<FireStar>().forceRange);
	}
}
