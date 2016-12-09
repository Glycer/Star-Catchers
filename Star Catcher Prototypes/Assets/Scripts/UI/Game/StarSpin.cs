using UnityEngine;
using System.Collections;

public class StarSpin : MonoBehaviour {

	public const float SPIN_DELAY = .02f;
	const float BASE_SPIN_Z = .5f;
	const float TIME_MOD = 60f;

	public TrackStars tracker;

	private float spin_z;
	private Vector3 spinSpeed;
	private Animator anim;
	RectTransform rectTransform;

	// Use this for initialization
	void Start () {
		Collection.LoseStars += FlashRed;
		LevelTimer.EndLevel += Unsubscribe;
		spin_z = (TIME_MOD / StaticVariables.levelDuration) * BASE_SPIN_Z;
		spinSpeed = new Vector3 (0, 0, spin_z);
		rectTransform = GetComponent<RectTransform> ();
		anim = GetComponent<Animator> ();

		StartCoroutine (Spin());
	}

	void FlashRed(int _unused)
	{
		if (anim != null)
			anim.Play ("FlashRed");
	}

	IEnumerator Spin()
	{
		for (float i = 0; i < StaticVariables.levelDuration; i += SPIN_DELAY) {
			rectTransform.Rotate (spinSpeed);
			spinSpeed.z = spin_z * tracker.starsNum;

			yield return new WaitForSeconds (SPIN_DELAY);
		}
	}

	/*
	IEnumerator SpinBySprint()
	{
		for (float i = 0; i < StaticVariables.levelDuration; i += SPIN_DELAY) {
			rectTransform.Rotate (spinSpeed);
			spinSpeed.z = spin_z * Sprint.sprintNum / 2;

			yield return new WaitForSeconds (SPIN_DELAY);
		}
	}
	*/

	void Unsubscribe()
	{
		Collection.LoseStars -= FlashRed;
	}
}
