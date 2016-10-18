using UnityEngine;
using System.Collections;

public class Idle : MonoBehaviour {

	const int BLINK_FREQUENCY = 5;

	private Animator anim;
	private int rand;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void Blink()
	{
		rand = Random.Range (0, BLINK_FREQUENCY);
		if (rand == 0) {
			anim.Play ("BunnyIdleBlink");
		}
	}
}
