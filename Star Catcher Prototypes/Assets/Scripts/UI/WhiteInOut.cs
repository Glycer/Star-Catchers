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
		MainMenu.InitFade += DelayedFadeIn;
		MainMenu.FadeIn += FadeIn;
		MainMenu.ChangeScene += Unsubscribe;

		incrementDelayOut = INCREMENT * FADE_DURATION_OUT;
		incrementDelayIn = INCREMENT * FADE_DURATION_IN;

		tempCol = GetComponent<Image> ().color;
		tempCol.a = isFadingIn ? 1 : 0;
		GetComponent<Image> ().color = tempCol;
	}

	void FadeOut()
	{
		StartCoroutine (WhiteOut ());
	}

	public void FadeIn()
	{
		StartCoroutine (WhiteIn ());
	}

	public void DelayedFadeIn()
	{
		StartCoroutine (DelayedWhiteIn ());
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

		gameObject.SetActive(false);
	}

	IEnumerator DelayedWhiteIn()
	{
		yield return new WaitForSeconds (LogoFade.HOLD);
		StartCoroutine (WhiteIn());
	}

	void Unsubscribe()
	{
		LevelTimer.FadeOut -= FadeOut;
		MainMenu.InitFade -= DelayedFadeIn;
		MainMenu.FadeIn -= FadeIn;
	}
}
