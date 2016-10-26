using UnityEngine;
using System.Collections;

public class FlipChar : MonoBehaviour {

	public int facingX = 1;
	private SpriteRenderer sprite;

	void Start()
	{
		PlayerMotion.ChangeDirection += Flip;
		LevelTimer.EndLevel += Unsubscribe;

		sprite = GetComponent<SpriteRenderer> ();
	}

	void Flip()
	{
		if (GetComponent<SpriteRenderer> () != null) {
			if (Input.GetKeyDown ("left")) {
				sprite.flipX = true;
				facingX = -1;
			} else if (Input.GetKeyDown ("right")) {
				sprite.flipX = false;
				facingX = 1;
			}
		}
	}

	void Unsubscribe()
	{
		PlayerMotion.ChangeDirection -= Flip;
	}
}
