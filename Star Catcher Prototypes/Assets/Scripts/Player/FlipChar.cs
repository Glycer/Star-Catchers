using UnityEngine;
using System.Collections;

public class FlipChar : MonoBehaviour {

	private SpriteRenderer sprite;

	void Start()
	{
		PlayerMotion.ChangeDirection += Flip;

		sprite = GetComponent<SpriteRenderer> ();
	}

	void Flip()
	{
		if (Input.GetKeyDown ("left")) {
			sprite.flipX = true;
		} else if (Input.GetKeyDown ("right")) {
			sprite.flipX = false;
		}
	}
}
