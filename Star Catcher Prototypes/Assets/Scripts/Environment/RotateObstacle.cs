using UnityEngine;
using System.Collections;

public class RotateObstacle : MonoBehaviour {

	private int rand;
	private Vector3 rot;

	// Use this for initialization
	void Start () {
		rand = Random.Range (0, 360);
		rot = new Vector3 (rand, 0, 0);
		transform.Rotate (rot);
	}
}
