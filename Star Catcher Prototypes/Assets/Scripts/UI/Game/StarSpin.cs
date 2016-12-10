using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarSpin : MonoBehaviour {

	const int NUM_STEPS = 6;

	public Image img;

	public const float SPIN_DELAY = .02f;
	const float BASE_SPIN_Z = .2f;
	const float TIME_MOD = 60f;

	public TrackStars tracker;

	private float spin_z;
	private Vector3 spinSpeed;
	private Animator anim;
	RectTransform rectTransform;

	private Color tempCol = new Color (1, 1, 1);
	private Color incrementCol;

	private Color green = new Color (.5f, 1, .8f);

	// Use this for initialization
	void Start () {
		Collection.LoseStars += FlashRed;
		LevelTimer.EndLevel += Unsubscribe;
		spin_z = (TIME_MOD / StaticVariables.levelDuration) * BASE_SPIN_Z;
		spinSpeed = new Vector3 (0, 0, spin_z);
		rectTransform = GetComponent<RectTransform> ();

		img = GetComponent<Image> ();
		anim = GetComponent<Animator> ();

		incrementCol.r = green.r / NUM_STEPS;
		incrementCol.b = green.b / NUM_STEPS;

		StartCoroutine (Spin());
	}

	void FlashRed(int _unused)
	{
		//StartCoroutine (FlashRed ());
		if (anim != null)
			anim.Play ("FlashRed");
	}

	public void FlashBlue()
	{
		if (anim != null)
			anim.Play ("FlashBlue");
	}

	public void CheckCol()
	{
		int _colNum = tracker.mileMarker / 10;

		tempCol.r = 1 - (incrementCol.r * _colNum);
		tempCol.b = 1 - (incrementCol.b * _colNum);

		img.color = tempCol;
	}

	public void SetCol()
	{
		img.color = tempCol;
		//Debug.Log (img.color);
	}

	IEnumerator Spin()
	{
		for (float i = 0; i < StaticVariables.levelDuration; i += SPIN_DELAY) {
			rectTransform.Rotate (spinSpeed);
			spinSpeed.z = spin_z * tracker.starsNum;

			yield return new WaitForSeconds (SPIN_DELAY);
		}
	}

	IEnumerator FlashRed()
	{
		for (int i = 0; i < 3; i++) {
			GetComponent<Image> ().color = Color.white;
			yield return new WaitForSeconds (.15f);
			GetComponent<Image> ().color = Color.red;
		}

		GetComponent<Image> ().color = Color.white;
	}

	void Unsubscribe()
	{
		Collection.LoseStars -= FlashRed;
	}
}
