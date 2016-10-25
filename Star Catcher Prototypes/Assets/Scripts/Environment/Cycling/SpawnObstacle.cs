using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnObstacle : MonoBehaviour {

	private GameObject preFab;

	// Use this for initialization
	void Start () {
		CameraMotion.ResetAll += CleanUp;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn(List<GameObject> obstacles)
	{
		int rand = Random.Range(0, obstacles.Count);
		if (rand == obstacles.Count) {
			return;
		} else {
			preFab = Instantiate (obstacles [rand]);
			preFab.transform.SetParent (transform);
			preFab.transform.position = transform.position;
		}
	}

	public void CleanUp()
	{
		if (preFab != null)
			Destroy (preFab);
	}
}
