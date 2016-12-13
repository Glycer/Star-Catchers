using UnityEngine;
using System.Collections;

public class SpawnStars : MonoBehaviour {

	const float MIN_SPAWN_DELAY = 0.3f;
	const float MAX_SPAWN_DELAY = 1.5f;

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

	void SpawnStar(Transform _spawner)
	{
		int _randStar = Random.Range (0, stars.Length);

		GameObject star = Instantiate (stars[_randStar]);
		float _rand = Random.Range (0, _spawner.GetComponent<FireStar>().forceRange.x);

		star.transform.position = _spawner.position;
		star.GetComponent<Rigidbody> ().AddForce (_rand, _spawner.GetComponent<FireStar>().forceRange.y, 0);
	}
}
