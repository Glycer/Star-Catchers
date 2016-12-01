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
			if (Input.GetKey ("left")) {
				sprite.flipX = true;
				facingX = -1;
			} else if (Input.GetKey ("right")) {
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
