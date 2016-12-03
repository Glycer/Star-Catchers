using UnityEngine;
using System.Collections;

public class StarSpin : MonoBehaviour {

	public const float SPIN_DELAY = .02f;
	const float SPIN_Z = .5f;

	public TrackStars tracker;

	private Vector3 spinSpeed;
	RectTransform rectTransform;

	// Use this for initialization
	void Start () {
		Collection.LoseStars += FlashRed;
		spinSpeed = new Vector3 (0, 0, SPIN_Z);
		rectTransform = GetComponent<RectTransform> ();

		StartCoroutine (Spin());
	}

	void FlashRed(int _unused)
	{
		GetComponent<Animator> ().Play ("FlashRed");
	}

	IEnumerator Spin()
	{
		for (float i = 0; i < StaticVariables.levelDuration; i += SPIN_DELAY) {
			rectTransform.Rotate (spinSpeed);
			spinSpeed.z = SPIN_Z * tracker.starsNum;

			yield return new WaitForSeconds (SPIN_DELAY);
		}
	}

	void Unsubscribe()
	{
		Collection.LoseStars -= FlashRed;
	}
}
