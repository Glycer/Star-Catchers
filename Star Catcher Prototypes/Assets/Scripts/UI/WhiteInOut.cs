using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WhiteInOut : MonoBehaviour {

	public const float FADE_DURATION_OUT = 3;
	public const float FADE_DURATION_IN = .25f;
	public const float INCREMENT = 1f/30f;

	public bool isFadingIn;

	private float incrementDelayIn;
	private float incrementDelayOut;
	private Color tempCol;

	// Use this for initialization
	void Start () {
		LevelTimer.FadeOut += FadeOut;
		LevelTimer.EndLevel += Unsubscribe;
		MainMenu.FadeIn += FadeIn;
		MainMenu.ChangeScene += Unsubscribe;

		incrementDelayOut = INCREMENT * FADE_DURATION_OUT;
		incrementDelayIn = INCREMENT * FADE_DURATION_IN;

		tempCol = isFadingIn ? new Color (1, 1, 1, 1) : new Color (1, 1, 1, 0);
		GetComponent<Image> ().color = tempCol;
	}

	void FadeOut()
	{
		StartCoroutine (WhiteOut ());
	}

	void FadeIn()
	{
		StartCoroutine (WhiteIn ());
	}

	IEnumerator WhiteOut()
	{
		for (float i = 0; i < 1; i += INCREMENT) {
			tempCol.a += INCREMENT;
			GetComponent<Image> ().color = tempCol;

			yield return new WaitForSeconds (incrementDelayOut);
		}
	}

	IEnumerator WhiteIn()
	{
		for (float i = 0; i < 1; i += INCREMENT) {
			tempCol.a -= INCREMENT;
			GetComponent<Image> ().color = tempCol;

			yield return new WaitForSeconds (incrementDelayIn);
		}

		Destroy (gameObject);
	}

	void Unsubscribe()
	{
		LevelTimer.FadeOut -= FadeOut;
		MainMenu.FadeIn -= FadeIn;
	}
}
